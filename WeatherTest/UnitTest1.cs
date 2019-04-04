using NUnit.Framework;
using Weather_Statistic.Models;

namespace Tests
{
    public class Tests
    {
        KeyApi KeyApi = new KeyApi();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LoadWeatherTest()
        {
            string result = KeyApi.LoadWeatherApi();
            Assert.AreNotEqual(null, result);
        }

        [Test]
        public void LoadLocationTest()
        {
            string result = KeyApi.LoadLocationApi();
            Assert.AreNotEqual(null,result);
        }
    }
}