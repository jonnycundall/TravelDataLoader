using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using DataSetLoader.Repository;
using System.IO;

namespace DataSetLoader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Looking for files in {0}", Properties.Settings.Default.NaPTANFileLocation);

            var fileLoader = new FileLoader();

            //var naptanFile = fileLoader.GetNaPTANFileLocation();

            //Console.WriteLine("Found NaPTAN file");

            //var napTanParser = new NaPTANStreamParser();

            var repo = new MongoRepository();

            //var stops = napTanParser.Process(naptanFile);

            
            //foreach (var stop in stops)
            //{
            //    repo.SaveStop(stop);
            //}

            //Console.WriteLine("Saved {0} stops", stops.Count());

            var files = fileLoader.GetTravelineFiles();

            Console.WriteLine("Found {0} xml files", files.Count());

            var fileParser = new TravelineDocumentParser();
            var rawRoutes = new List<RawRoute>();

            var routeMunger = new RouteMunger(repo);
            foreach (var filePath in files)
            {
                var document = XDocument.Load(filePath);
                Console.WriteLine("processing {0}", filePath);
                routeMunger.Munge(fileParser.Process(document));
            }
            


            
        }
    }
}
