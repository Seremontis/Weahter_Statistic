using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Weather_Statistic.Models;

namespace Tests
{
    [TestFixture]
    public class WeatherConnectTest
    {
        WeatherConnect weather;

        [SetUp]
        public void Setup()
        {
            weather = new WeatherConnect();
        }

        [Test]
        [TestCase((long)31.170510, (long)7.857358,"2019-04-10")]
        [TestCase((long)64.536929, (long)17.852616, "2019-04-08")]
        [TestCase((long)59.913868, (long)10.752245, "2019-01-10")]
        public async Task HistoricalWaetherTest(long x,long y, DateTime datetime)
        {
            var result =await weather.ResultOneSearch(x, y, datetime);
            Assert.IsNotNull(result);
        }

        [Test]
        [TestCase((long)31.170510, (long)7.857358)]
        [TestCase((long)64.536929, (long)17.852616)]
        [TestCase((long)59.913868, (long)10.752245)]
        public async Task ForecastTest(long x, long y)
        {
            var result = await weather.ResultOneSearch(x, y,DateTime.Now);
            Assert.IsNotNull(result);
        }
    }
}
