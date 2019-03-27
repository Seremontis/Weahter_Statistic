using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weather_Statistic.Models
{
    public class MultiDayCompares
    {
        public MultiDayCompares()
        {
            City1 = new List<OneInfoModel>();
            City2 = new List<OneInfoModel>();
        }
        public List<OneInfoModel> City1;
        public List<OneInfoModel> City2;
    }
}
