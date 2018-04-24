using ExifLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiritPointsClient
{
    public static class LocationManager
    {
        public static string Location_Load()
        {
            double[] latlong = GetLatLongFromImage(@"D:\Dropbox\Photoshop\Iphone.jpeg");
            string url = "https://www.google.com/maps/place/" + latlong[0] + "," + latlong[1];
            return url;
        }

        private static double[] GetLatLongFromImage(string imagePath)
        {
            ExifReader reader = new ExifReader(imagePath);

            // EXIF lat/long tags stored as [Degree, Minute, Second]
            double[] latitudeComponents;
            double[] longitudeComponents;

            string latitudeRef; // "N" or "S" ("S" will be negative latitude)
            string longitudeRef; // "E" or "W" ("W" will be a negative longitude)

            if (reader.GetTagValue(ExifTags.GPSLatitude, out latitudeComponents)
                && reader.GetTagValue(ExifTags.GPSLongitude, out longitudeComponents)
                && reader.GetTagValue(ExifTags.GPSLatitudeRef, out latitudeRef)
                && reader.GetTagValue(ExifTags.GPSLongitudeRef, out longitudeRef))
            {

                var latitude = ConvertDegreeAngleToDouble(latitudeComponents[0], latitudeComponents[1], latitudeComponents[2], latitudeRef);
                var longitude = ConvertDegreeAngleToDouble(longitudeComponents[0], longitudeComponents[1], longitudeComponents[2], longitudeRef);
                return new[] { latitude, longitude };
            }

            return null;
        }

        private static double ConvertDegreeAngleToDouble(double degrees, double minutes, double seconds, string latLongRef)
        {
            double result = ConvertDegreeAngleToDouble(degrees, minutes, seconds);
            if (latLongRef == "S" || latLongRef == "W")
            {
                result *= -1;
            }
            return result;
        }

        private static double ConvertDegreeAngleToDouble(double degrees, double minutes, double seconds)
        {
            return degrees + (minutes / 60) + (seconds / 3600);
        }
    }
}
