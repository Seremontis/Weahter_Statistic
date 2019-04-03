using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather_Statistic.Models;

namespace Weather_Statistic
{
    public class CollectData
    {
        private MultiDaysCompares modelsResult;
        private List<OneInfoModel> infoModel;

        public CollectData()
        {
            modelsResult = new MultiDaysCompares();
            infoModel = new List<OneInfoModel>();
        }

        public MultiDaysCompares CreateList(string town1, string town2,int days)
        {
            var geo = DownLocation(town1, town2);
            DateTime time = DateTime.Now;
            for (int i = 0; i < days; i++)
            {
                modelsResult.City1.Add(DownWeather(geo[0].Item1,geo[0].Item2,time.AddDays(-1-i)));
                modelsResult.City2.Add(DownWeather(geo[1].Item1, geo[1].Item2, time.AddDays(-1- i)));
            }
            modelsResult.City1[0].Place = geo[0].Item3;
            modelsResult.City2[0].Place = geo[1].Item3;
            return modelsResult;
        }
        public List<OneInfoModel> CreateList(string town, int days)
        {
            var geo = DownLocation(town);
            DateTime time = DateTime.Now;
            for (int i = 0; i < days; i++)
            {
                infoModel.Add(DownWeather(geo.Item1, geo.Item2, time.AddDays(-1 - i)));
            }
            if (infoModel != null){
                infoModel[0].Place = geo.Item3;
            }
            
            return infoModel;
        }

        private (double, double, string)[] DownLocation(string town1, string town2)
        {
            var name = new LocationName();
            (double, double, string)[] locations = { (name.GetPoint(town1)), (name.GetPoint(town2)) };
            return locations;
        }
        private (double, double, string) DownLocation(string town)
        {
            var name = new LocationName();
            (double, double, string) locations = name.GetPoint(town);
            return locations;
        }

        private OneInfoModel DownWeather(double lati,double lang, DateTime date)
        {
            var weather = new WeatherConnect();
            OneInfoModel info = weather.ResultOneSearch(lati,lang,date).Result;
            return info;
        }


    }
}
