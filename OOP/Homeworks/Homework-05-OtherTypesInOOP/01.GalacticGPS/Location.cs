namespace _01.GalacticGPS
{
    using System;

    struct Location
    {
        private double latitude;
        private double longitude;

        public Location(double latitude, double longitude, Planet planet)
            : this()
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Planet = planet;
        }

        public double Latitude
        {
            get
            {
                return this.latitude;
            }

            set
            {
                if (value < -90 || 90 < value)
                {
                    throw new ArgumentOutOfRangeException("latitude", "The valid values for latitude are in the range [-90 ... 90].");
                }

                this.latitude = value;
            }
        }

        public double Longitude
        {
            get
            {
                return this.longitude;
            }

            set
            {
                if (value < -180 || 180 < value)
                {
                    throw new ArgumentOutOfRangeException("longitude", "The valid values for longitude are in the range [-180 ... 180].");
                }

                this.longitude = value;
            }
        }

        public Planet Planet { get; set; }

        public override string ToString()
        {
            string result = string.Format(
                "{0}, {1} - {2}",
                this.Latitude,
                this.Longitude,
                this.Planet);

            return result;
        }
    }
}
