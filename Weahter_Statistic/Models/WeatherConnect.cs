using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DarkSkyApi;
using DarkSkyApi.Models;

namespace Weather_Statistic.Models
{
    public class WeatherConnect
    {
        readonly DarkSkyService client = new DarkSkyService("63713b898acfdab954a9dd0ecea69e3c");

        async public Task<OneInfoModel> ResultOneSearch(double lati,double longti)
        {
            var exclusionList = new List<Exclude> { Exclude.Currently,Exclude.Hourly };
            DateTime yesterday = DateTime.Now.AddDays(-1);
            Forecast result = await client.GetTimeMachineWeatherAsync(lati, longti, yesterday, Unit.Auto, exclusionList);
            var cut = result.Daily.Days[0];
            OneInfoModel oneInfo = new OneInfoModel
            {             
                Pressure= cut.Pressure,
                Humadity=cut.Humidity,
                Cloudy = cut.CloudCover,
                Sunrise = cut.SunriseTime.DateTime,
                Sunset = cut.SunsetTime.DateTime
            };
            return oneInfo;          
        }
    }
}
