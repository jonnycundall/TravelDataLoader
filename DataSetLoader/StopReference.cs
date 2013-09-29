using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataSetLoader
{
    public class StopReference
    {
        private string _reference;
        public StopReference(string reference)
        {
            _reference = reference;
        }

        public string Reference
        {
            get { return _reference; }
        }
    }

    public class RouteReference
    {
        private string _reference;
        public RouteReference(string reference)
        {
            _reference = reference;
        }

        public string Reference
        {
            get { return _reference; }
        }
    }

    public static class StringExtensions
    {
        public static StopReference ToStopReference(this string reference)
        {
            return new StopReference(reference);
        }

        public static RouteReference ToRouteReference(this string reference)
        {
            return new RouteReference(reference);
        }
    }
}
