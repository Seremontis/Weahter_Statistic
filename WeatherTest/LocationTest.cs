using NUnit.Framework;
using Weather_Statistic.Models;

namespace Tests
{
    [TestFixture]
    public class LocationTest
    {
        LocationName location;

        [SetUp]
        public void Setup()
        {
            location = new LocationName();
        }

        [Test]
        [TestCase("Warszawa")]
        [TestCase("Kopenhaga")]
        [TestCase("Grenlandia")]
        public void GetPointTest(string city)
        {
            var result = location.GetPoint(city);
            Assert.IsNotNull(result);
        }
    }
}
