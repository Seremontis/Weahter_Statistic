using System.Collections.Generic;

namespace Weather_Statistic.Models
{
    //Extend model
    public class MultiDaysComparesModel
    {
        public MultiDaysComparesModel()
        {
            City1 = new List<OneInfoModel>();
            City2 = new List<OneInfoModel>();
        }
        public List<OneInfoModel> City1;
        public List<OneInfoModel> City2;
    }
}
