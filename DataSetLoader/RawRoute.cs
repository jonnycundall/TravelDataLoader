using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataSetLoader
{
    public class RawRoute
    {
        public IEnumerable<RouteLink> RouteLinks { get; set; }
        public string RouteName { get; set; }
    }
}
