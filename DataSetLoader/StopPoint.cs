using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataSetLoader
{
    public class StopPoint
    {
        public StopPoint(string code, double longitude, double latitude)
        {
            this.code = code;
            this.longitude = longitude;
            this.latitude = latitude;
        }
        
        public string code;
        public double longitude;
        public double latitude;
    }

    public class StopNotFound : StopPoint
    {
        public StopNotFound() : base("NOTFOUND",0,0)
        {
            
        }

        
    }
}
