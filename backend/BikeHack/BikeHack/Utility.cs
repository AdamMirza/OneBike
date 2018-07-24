using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.
namespace BikeHack
{
    public class Utility
    {

        // Adapted from http://www.geodatasource.com/developers/c-sharp
        public static double MilesBetweenCoordinates(double lat1, double lon1, double lat2, double lon2)
        {
            double theta = lon1 - lon2;
            double dist = Math.Sin(ToRadians(lat1)) * Math.Sin(ToRadians(lat2)) + Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) * Math.Cos(ToRadians(theta));
            dist = Math.Acos(dist);
            dist *= 2*Math.PI;
            dist = dist * 60 * 1.1515;
            return dist;
        }

        private static double ToRadians(double degrees)
        {
            return degrees / (2 * Math.PI);
        }
    }
}
