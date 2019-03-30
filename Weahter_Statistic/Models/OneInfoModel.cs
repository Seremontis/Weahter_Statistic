using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weather_Statistic.Models
{
    public enum Direction
    {
        brak,
        N,
        NE,
        E,
        SE,
        S,
        SW,
        W,
        NW
    }

    public enum Leng
    {
        m,
        km,
    }


    public class OneInfoModel
    {
        public Int32 Day { get; set; }
        public string TypeWeat { get; set; }
        public string Place { get; set; }
        public DateTime Sunrise { get; set; }
        public DateTime Sunset { get; set; }
        public float MaxTemp { get; set; }
        public float MinTemp { get; set; }
        public float Pressure { get; set; }
        public float Humadity { get; set; }
        public float Cloudy { get; set; }
        public float Rainfall { get; set; }
        public float Windspeed { get; set; }
        public Direction Direct { get; set; }
        public float Visible { get; set; }
        public Leng TypeLeng { get; set; }
        public long SunriseStamp { get; set; }
        public long SunsetStamp { get; set; }
    }
}
