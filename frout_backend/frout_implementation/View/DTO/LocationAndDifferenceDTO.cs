using frout_implementation.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace frout_implementation.View.DTO
{
    public class LocationAndDifferenceDTO
    {
        public LocationAndDifferenceDTO(Subscription subscription, double latitude, double longitude, double difference)
        {
            Longitude = longitude;
            Latitude = latitude;
            Difference = difference;
            Subscription = subscription;
        }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double Difference { get; set; }
        public Subscription Subscription { get; set; }

        public static double Distance(double lat1, double lon1, double lat2, double lon2, char unit)
        {
            double theta, dist;
            theta = lon1 - lon2;
            dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
            dist = Math.Acos(dist);
            dist = rad2deg(dist);
            dist = dist * 60 * 1.1515;
            switch (unit)
            {
                case 'M':
                    break;
                case 'K':
                    dist = dist * 1.609344;
                    break;
                case 'N':
                    dist = dist * 0.8684;
                    break;
            }
            return (dist);
        }

        private static double rad2deg(double rad)
        {
            return (rad * 180 / Math.PI);
        }

        private static double deg2rad(double deg)
        {
            return (deg * Math.PI / 180);
        }
    }
}
