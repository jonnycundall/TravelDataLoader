using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusRoutesService
{
    public interface IBusRouteService
    {
        byte[] FindRoutes(GeoBounds bounds);
    }

    public struct GeoBounds
    {
        public double LongitudeWest;
        public double LongitudeEast;
        public double LatitudeNorth;
        public double LatitudeSouth;
    }

    public class BusRoutesService : IBusRouteService
    {
        public byte[] FindRoutes(GeoBounds bounds)
        {
            //do mongo query to find routes with at least one point in bounds

            // stick found routes together in one document

            throw new NotImplementedException();
        }
    }
}
