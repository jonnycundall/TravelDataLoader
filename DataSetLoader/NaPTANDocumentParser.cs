using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;

namespace DataSetLoader
{
    public class NaPTANStreamParser
    {
        public IEnumerable<StopPoint> Process(string filePath)
        {
            XNamespace naptanNamespace = "http://www.naptan.org.uk/";

            var streamQuery =
                from c in StreamElements(filePath,  "StopPoint")
                select c;

            foreach(var stopElement in streamQuery)
            {
                var translation = stopElement
                    .Element(naptanNamespace + "Place")
                    .Element(naptanNamespace + "Location")
                    .Element(naptanNamespace + "Translation");
                yield return new StopPoint(
                    stopElement.Element(naptanNamespace + "AtcoCode").Value,
                    double.Parse(translation.Element(naptanNamespace + "Longitude").Value),
                    double.Parse(translation.Element(naptanNamespace + "Latitude").Value));
           
            }
        }

        private static IEnumerable<XElement> StreamElements(
            string fileName,
            string elementName)
        {
            using (var rdr = XmlReader.Create(fileName))
            {
                rdr.MoveToContent();
                while (rdr.Read())
                {
                    if ((rdr.NodeType == XmlNodeType.Element) && (rdr.Name == elementName))
                    {
                        var e = XElement.ReadFrom(rdr) as XElement;
                        yield return e;
                    }
                }
                rdr.Close();
            }
        }
    }
}
