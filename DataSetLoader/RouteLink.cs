using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataSetLoader
{
    public class RouteLink
    {
        public RouteLink(StopReference fromStopReference, StopReference toStopReference)
        {
            FromStopReference = fromStopReference;
            ToStopReference = toStopReference;
        }
        public StopReference FromStopReference;
        public StopReference ToStopReference;
    }
}
