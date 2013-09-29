using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataSetLoader.Repository
{
    public interface IRepository
    {
        void SaveStop(StopPoint stopPoint);

        void SaveRoute(RawRoute route, IEnumerable<StopPoint> stops, GeoBounds bounds);

        RawRoute GetRoute(RouteReference routeReference);

        StopPoint GetStop(StopReference stopReference);

        void LogError(string category, params string[] data);
    }
}
