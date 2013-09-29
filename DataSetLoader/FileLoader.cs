using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DataSetLoader
{
    public class FileLoader
    {
        public string[] GetTravelineFiles()
        {
            return Directory.GetFiles(Properties.Settings.Default.TravelineFileLocation, "*.xml");
        }

        public string GetNaPTANFileLocation()
        {
            return Directory.GetFiles(Properties.Settings.Default.NaPTANFileLocation, "*.xml").First();
        }
    }
}
