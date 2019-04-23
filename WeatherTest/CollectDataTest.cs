using NUnit.Framework;
using Weather_Statistic;

namespace Tests
{
    [TestFixture]
    class CollectDataTest
    {
        CollectData collect;

        [SetUp]
        public void Setup()
        {
            collect = new CollectData();
        }

        [Test]
        [TestCase("Berlin","Londyn",3)]
        [TestCase("Madryt", "Porto", 3)]
        [TestCase("Kraków", "Katowice", 5)]
        public void CreateListTest(string city1, string city2, int days)
        {
            var result = collect.CreateList(city1, city2, days);
            Assert.IsNotNull(result);
        }

        [Test]
        [TestCase("Berlin", 5)]
        [TestCase("Londyn", 3)]
        [TestCase("Warszawa", 5)]
        public void CreateListTest(string city,int day)
        {
            var result = collect.CreateList(city, day);
            Assert.IsNotNull(result);
        }


        [Test]
        [TestCase("Berlin")]
        [TestCase("Londyn")]
        [TestCase("Warszawa")]
        public void CreateListFutureTest(string city)
        {
            var result = collect.CreateListFuture(city);
            Assert.IsNotNull(result);
        }
    }
}
