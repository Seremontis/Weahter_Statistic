using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weather_Statistic.Models
{
    public class OneInfoModel
    {
        public string place { get; set; }
        public DateTime Sunrise { get; set; }
        public DateTime Sunset { get; set; }
        public int MaxTemp { get; set; }
        public int MinTemp { get; set; }
        public float Pressure { get; set; }
        public float Humadity { get; set; }
        public float Cloudy { get; set; }
        public float Rainfall { get; set; }
    }
}
