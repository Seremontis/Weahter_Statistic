using System;
using System.Linq;

namespace Weather_Statistic.Models
{
    /// <summary>
    /// Primary operations statistic
    /// </summary>
    public class StatisticOperation
    {
        public float Median(float[] array)
        {
            int count = array.Count();
            Array.Sort(array);
            float res = (array[count / 2] + array[(count / 2) - 1]) / 2;
            return res;
        }

        public double Devation(float[] array)
        {
            float avg = array.Average();
            double res = 0;
            for (int i = 0; i < array.Count(); i++)
            {
                res += Math.Pow(array[i] - avg, 2);
            }
            res /= array.Count();
            res = Math.Sqrt(res);
            return res;
        }
    }
}
