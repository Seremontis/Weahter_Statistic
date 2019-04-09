using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DarkSkyApi;
using DarkSkyApi.Models;

namespace Weather_Statistic.Models
{
    /// <summary>
    /// Weather API to connect of data
    /// </summary>
    public class WeatherConnect
    {
        readonly DarkSkyService client;

        public WeatherConnect()
        {
            KeyApi key = new KeyApi();
            client = new DarkSkyService(key.LoadWeatherApi());
        }

        async public Task<OneInfoModel> ResultOneSearch(double lati,double longti,DateTime dateTime)
        {
            var exclusionList = new List<Exclude> { Exclude.Currently,Exclude.Hourly, };
            Forecast result = await client.GetTimeMachineWeatherAsync(lati, longti, dateTime, Unit.Auto, exclusionList);
            var cut = result.Daily.Days[0];
            OneInfoModel oneInfo = new OneInfoModel
            {
                Day = cut.Time.ToUnixTime(),
                Pressure = cut.Pressure,
                Humadity = cut.Humidity * 100,
                Cloudy = (int)(cut.CloudCover * 100),
                Sunrise = cut.SunriseTime.DateTime.AddHours(2),
                Sunset = cut.SunsetTime.DateTime.AddHours(2),
                Rainfall = cut.PrecipitationIntensity,
                TypeWeat = cut.PrecipitationType,
                MaxTemp = cut.HighTemperature,
                MinTemp = cut.LowTemperature,
                Windspeed = (float)(Math.Round(cut.WindSpeed * 1.609344, 2)),
                Direct = ConvertDirect(cut.WindBearing),
                DirectNumber=cut.WindBearing,
                Visible = cut.Visibility < 1 ? cut.Visibility * 1000 : cut.Visibility,
                TypeLeng = cut.Visibility < 1 ? Leng.m : Leng.km,
                SunriseTime = ListTime(cut.SunriseTime.TimeOfDay),
                SunsetTime = ListTime(cut.SunsetTime.TimeOfDay)
            };      
            return oneInfo;                 
        }

        async public Task<List<OneInfoModel>> FutureResult(double lati, double longti, DateTime dateTime)
        {
            var exclusionList = new List<Exclude> { Exclude.Currently};
            Forecast result = await client.GetTimeMachineWeatherAsync(lati, longti, dateTime, Unit.Auto, exclusionList);
            var cut = result.Hourly.Hours;
            List<OneInfoModel> list = new List<OneInfoModel>();
            foreach (var item in cut)
            {
                OneInfoModel oneInfo = new OneInfoModel
                {
                    Day = item.Time.ToUnixTime(),
                    Pressure = item.Pressure,
                    Sunrise = result.Daily.Days[0].SunriseTime.DateTime,
                    Sunset = result.Daily.Days[0].SunsetTime.DateTime,
                    SunriseTime = ListTime(item.Time.TimeOfDay),
                    Rainfall = item.PrecipitationIntensity,
                    TypeWeat = item.PrecipitationType,
                    MaxTemp = item.Temperature,
                    Windspeed = (float)(Math.Round(item.WindSpeed * 1.609344, 2)),
                    Direct = ConvertDirect(item.WindBearing),
                    DirectNumber = item.WindBearing,
            };
                list.Add(oneInfo);
            }
            return list;
        }

        private List<int> ListTime(TimeSpan day)
        {
            List<int> temp = new List<int>();
            temp.Add(day.Hours);
            temp.Add(day.Minutes);
            temp.Add(day.Seconds);
            return temp;
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
