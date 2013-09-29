using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace DataSetLoader
{
    public class TravelineDocumentParser
    {
        public RawRoute Process(XDocument document)
        {
            XNamespace transXChangeNamespace = "http://www.transxchange.org.uk/";
            
            var rawLinks =  document.Root
                .Descendants(transXChangeNamespace + "RouteLink")
                .Select(rl =>
                    new RouteLink(
                        rl.Element(transXChangeNamespace + "From").Element(transXChangeNamespace + "StopPointRef").Value.ToStopReference(),
                        rl.Element(transXChangeNamespace + "To").Element(transXChangeNamespace + "StopPointRef").Value.ToStopReference())
                        );

            var routeName = document.Root
                .Descendants(transXChangeNamespace + "ServiceRef")
                .First().Value;

            return new RawRoute { RouteName = routeName, RouteLinks = rawLinks };
        }
    }
}
