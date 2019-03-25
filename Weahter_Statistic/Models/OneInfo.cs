using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weather_Statistic.Models
{
    public class OneInfo
    {
        public DateTime Sunrise { get; set; }
        public DateTime Sunset { get; set; }
        public int MaxTemp { get; set; }
        public int MinTemp { get; set; }
        public int Pressure { get; set; }
        public int Humadity { get; set; }
        public float Cloudy { get; set; }
        public int Rainfall { get; set; }
    }
}
