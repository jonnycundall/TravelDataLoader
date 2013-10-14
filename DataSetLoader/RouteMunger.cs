using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataSetLoader.Repository;

namespace DataSetLoader
{
    public class RouteMunger
    {
        IRepository _repository;

        public RouteMunger(IRepository repository)
        {
            _repository = repository;
        }

        public void Munge(RawRoute rawRoute)
        {
            // get all stops on route
            // if you don't find them, log the rout in the fails pile
            var lastStop = _repository.GetStop(rawRoute.RouteLinks.Last().ToStopReference);
            var stopsInSequence = rawRoute.RouteLinks
                .Select(rl => _repository.GetStop(rl.FromStopReference))
                .Union(new[]{lastStop})
                .Where(s => s.code != "NOTFOUND");

            if (!stopsInSequence.Skip(1).Any()) //linestring requires at least 2 stops
            {
                _repository.LogError("NOSTOPS",rawRoute.RouteName);
                return;
            }

            //calculate the bounds of the route for indexing/caching
            var bounds = new GeoBounds(new LonLat(stopsInSequence.Max(sp => sp.longitude),stopsInSequence.Min(sp => sp.latitude)),
                new LonLat(stopsInSequence.Min(sp => sp.longitude), stopsInSequence.Max(sp => sp.latitude)) 
            );
            //save route in DB
            _repository.SaveRoute(rawRoute, stopsInSequence, bounds); 
        }
    }
}
