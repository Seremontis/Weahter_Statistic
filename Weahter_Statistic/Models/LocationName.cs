using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenCage.Geocode;

namespace Weather_Statistic.Models
{
    public class LocationName
    {
       readonly Geocoder service = new Geocoder("03029b67e6bc4cd6a6c9f9157702df80");

        public (double,double,string) GetPoint(string name)
        {
            var value = service.Geocode(name,"pl");
            var s = value.Results;
            double latitude = value.Results[0].Geometry.Latitude;
            double longtitude = value.Results[0].Geometry.Longitude;
            string detail = value.Results[0].Components.City;

            return (latitude,longtitude,detail);
        }

        internal object GetPoint()
        {
            throw new ArgumentNullException();
        }
    }
}
