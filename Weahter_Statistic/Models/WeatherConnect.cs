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

        async public Task<OneInfoModel> ResultOneSearch(double lati,double longti,DateTime dateTime)
        {
            var exclusionList = new List<Exclude> { Exclude.Currently,Exclude.Hourly };
            //DateTime yesterday = DateTime.Now.AddDays(-1);
            Forecast result = await client.GetTimeMachineWeatherAsync(lati, longti, dateTime, Unit.Auto, exclusionList);
            var cut = result.Daily.Days[0];
            OneInfoModel oneInfo = new OneInfoModel
            {
                Pressure = cut.Pressure,
                Humadity = cut.Humidity * 100,
                Cloudy = cut.CloudCover * 100,
                Sunrise = cut.SunriseTime.DateTime,
                Sunset = cut.SunsetTime.DateTime,
                Rainfall = cut.PrecipitationIntensity,
                TypeWeat = cut.PrecipitationType,
                MaxTemp = cut.HighTemperature,
                MinTemp = cut.LowTemperature,
                Windspeed = (float)(Math.Round(cut.WindSpeed * 1.609344, 2)),
                Direct = ConvertDirect(cut.WindBearing),
                Visible = cut.Visibility < 1 ? cut.Visibility * 1000 : cut.Visibility,
                TypeLeng = cut.Visibility < 1 ? Leng.m : Leng.km,
                SunriseStamp = cut.SunriseTime.TimeOfDay.Ticks,
                SunsetStamp = cut.SunsetTime.TimeOfDay.Ticks,
            };      
            return oneInfo;        
            
        }

        private Direction ConvertDirect(float degree)
        {
            Direction direction=0;
            switch (degree)
            {
                case float x when ((x >= 0 && x <= 25) || (x >335 && x <= 360)):
                    direction = Direction.N;
                    break;
                case float x when ((x > 25 && x <= 65)):
                    direction = Direction.NE;
                    break;
                case float x when ((x > 65 && x <= 115)):
                    direction = Direction.E;
                    break;
                case float x when ((x > 115 && x <= 155)):
                    direction = Direction.SE;
                    break;
                case float x when ((x > 155 && x <= 205)):
                    direction = Direction.S;
                    break;
                case float x when ((x > 205 && x <= 245)):
                    direction = Direction.SW;
                    break;
                case float x when ((x > 245 && x <= 300)):
                    direction = Direction.W;
                    break;
                case float x when ((x > 300 && x <= 335)):
                    direction = Direction.NW;
                    break;
            }

            return direction;
        }
    }
}
