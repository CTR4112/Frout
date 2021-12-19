using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace frout_implementation.Domain.Model.ValueObjects
{
    public class Location
    {
        //https://stackoverflow.com/questions/15965166/what-are-the-lengths-of-location-coordinates-latitude-and-longitude
        //Latitude valid values: -90 - +90
        //Longitude valid values: -180 - +180

        public Location() //Ef CORE needs empty constructor
        {
        }

        public Location(double latitude, double longitude)
        {
            if (latitude > 90 || latitude < -90 || longitude > 180 || longitude < -180)
                throw new InvalidOperationException("Longitude oder Latitude hat ein ungültiges Format!");
            Longitude = longitude;
            Latitude = latitude;
        }
        [Required]
        public double Longitude { get; set; } // setter must be public otherwise location is null in post-controller
        [Required]
        public double Latitude { get; set; }
    }
}
