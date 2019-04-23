using NUnit.Framework;
using Weather_Statistic.Models;

namespace Tests
{
    public class ConnectApiTest
    {
        KeyApi KeyApi = new KeyApi();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void KeyConnect()
        {
            Assert.AreNotEqual(null, KeyApi);
        }

        [Test]
        public void LoadWeatherTest()
        {
            var result = KeyApi.LoadWeatherApi();
            Assert.IsNotNull(result);
        }

        [Test]
        public void LoadLocationTest()
        {
            var result = KeyApi.LoadLocationApi();
            Assert.IsNotNull(result);
        }

    }
}