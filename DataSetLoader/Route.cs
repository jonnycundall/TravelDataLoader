using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataSetLoader
{
    public class GeographicalRoute
    {
        private GeoBounds Bounds;
        private IEnumerable<LonLat> Stops;
    }

    public struct GeoBounds
    {
        public GeoBounds(LonLat topLeft, LonLat bottomRight)
        {
            TopLeft = topLeft;
            BottomRight = bottomRight;
        }

        public LonLat TopLeft;
        public LonLat BottomRight;
    }

    public struct LonLat
    {
        public LonLat(double longitude, double latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }

        public double Longitude;
        public double Latitude;
    }
}
