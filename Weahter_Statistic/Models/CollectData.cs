using System;
using System.Collections.Generic;
using Weather_Statistic.Models;

namespace Weather_Statistic
{
    /// <summary>
    /// Generate Lists to models
    /// </summary>
    public class CollectData
    {
        private MultiDaysComparesModel modelsResult;
        private List<OneInfoModel> infoModel;

        public CollectData()
        {
            modelsResult = new MultiDaysComparesModel();
            infoModel = new List<OneInfoModel>();
        }

        //Create list for two towns
        public MultiDaysComparesModel CreateList(string town1, string town2,int days)
        {
            var geo = DownLocation(town1, town2);
            DateTime time = DateTime.Now;
            for (int i = days-1; i >=0; i--)
            {
                modelsResult.City1.Add(DownWeather(geo[0].Item1,geo[0].Item2,time.AddDays(-1-i)));
                modelsResult.City2.Add(DownWeather(geo[1].Item1, geo[1].Item2, time.AddDays(-1- i)));
            }
            modelsResult.City1[0].Place = geo[0].Item3;
            modelsResult.City2[0].Place = geo[1].Item3;
            return modelsResult;
        }

        //Create list to one towns
        public List<OneInfoModel> CreateList(string town, int days)
        {
            var geo = DownLocation(town);
            DateTime time = DateTime.Now;
            for (int i = days-1; i >= 0; i--)
            {
                infoModel.Add(DownWeather(geo.Item1, geo.Item2, time.AddDays(-1 - i)));
            }
            if (infoModel != null){
                infoModel[0].Place = geo.Item3;
            }
            
            return infoModel;
        }

        //Create list for one town tomorrow
        public List<OneInfoModel> CreateListFuture(string town)
        {
            var geo = DownLocation(town);
            DateTime time = DateTime.Now;
            List<OneInfoModel> infoModel=DownWeatherFut(geo.Item1, geo.Item2, time.AddDays(1));
            infoModel[0].Place = town;
            return infoModel;
        }

        //Search location two towns
        private (double, double, string)[] DownLocation(string town1, string town2)
        {
            var name = new LocationName();
            (double, double, string)[] locations = { (name.GetPoint(town1)), (name.GetPoint(town2)) };
            return locations;
        }

        //Search location one town
        private (double, double, string) DownLocation(string town)
        {
            var name = new LocationName();
            (double, double, string) locations = name.GetPoint(town);
            return locations;
        }

        //Load data from API(past)
        private OneInfoModel DownWeather(double lati,double lang, DateTime date)
        {
            var weather = new WeatherConnect();
            OneInfoModel info = weather.ResultOneSearch(lati,lang,date).Result;
            return info;
        }

        //Load data from API(future)
        private List<OneInfoModel> DownWeatherFut(double lati, double lang, DateTime date)
        {
            var weather = new WeatherConnect();
            List<OneInfoModel> info = weather.FutureResult(lati, lang, date).Result;
            return info;
        }

    }
}
