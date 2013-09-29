using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Xml.Linq;
using DataSetLoader;

namespace DataSetLoaderTests
{
    [TestFixture]
    public class TravelineDocumentParserTests
    {
        [Test]
        public void IntegrationTestWithRealFile()
       { 
            var assembly = Assembly.GetExecutingAssembly();
            var textStreamReader = new StreamReader(assembly.GetManifestResourceStream("DataSetLoaderTests.resources.ea_20-4_-1-y08.xml"), Encoding.ASCII);
            var doc = XDocument.Load(textStreamReader.BaseStream);

            var parser = new TravelineDocumentParser();
            var routes = parser.Process(doc);
        }
    }
}
