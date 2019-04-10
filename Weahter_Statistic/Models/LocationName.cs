using System;
using OpenCage.Geocode;

namespace Weather_Statistic.Models
{
    /// <summary>
    /// Location API to identified places
    /// </summary>
    public class LocationName
    {
        readonly Geocoder service;

        public LocationName()
        {
            KeyApi key = new KeyApi();
            service = new Geocoder(key.LoadLocationApi());
        }

        public (double,double,string) GetPoint(string name)
        {
            var value = service.Geocode(name,"pl");
            var s = value.Results;
            double latitude = value.Results[0].Geometry.Latitude;
            double longtitude = value.Results[0].Geometry.Longitude;
            string detail = value.Results[0].Components.City;

            return (latitude,longtitude,detail);
        }
    }
}
