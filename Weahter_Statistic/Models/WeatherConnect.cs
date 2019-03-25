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

        async public Task<OneInfo> ResultOneSearch()
        {
            var exclusionList = new List<Exclude> { Exclude.Currently,Exclude.Hourly };
            DateTime curtime = DateTime.Now;
            curtime=curtime.AddDays(-1);
            Forecast result = await client.GetTimeMachineWeatherAsync(37.8267, -122.423, curtime, Unit.Auto, exclusionList);
            OneInfo oneInfo = new OneInfo
            {
                Cloudy = result.Daily.Days[0].CloudCover,
                Sunrise = result.Daily.Days[0].SunriseTime.DateTime,
                Sunset = result.Daily.Days[0].SunsetTime.DateTime
            };
            return oneInfo;          
        }
    }
}
