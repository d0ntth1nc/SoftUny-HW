using System;

namespace GalacticGPS
{
    internal struct Location
    {
        private double latitude;
        private double longitude;
        private Planet planet;

        public Location(double latitude, double longitude, Planet planet)
            :this()
        {
            this.latitude = latitude;
            this.longitude = longitude;
            this.planet = planet;
        }

        public override string ToString()
        {
            return String.Format("{0}, {1} - {2}", this.latitude, this.longitude, this.planet.ToString());
        }
    }
}
