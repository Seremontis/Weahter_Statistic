using System;
using System.Linq;
using NUnit.Framework;
using Weather_Statistic.Models;

namespace Tests
{
    [TestFixture]
    public class StatisticOperationTest
    {
        StatisticOperation statistic;

        [SetUp]
        public void Setup()
        {
            statistic = new StatisticOperation();
        }

        [Test]
        [TestCase(new float[] { 12, 16, 20,33,55,77 })]
        [TestCase(new float[] { 18, 22, 10,66,11,25 })]
        [TestCase(new float[] { 12, 11, 20,1,98,20 })]
        public void MedianTest(float[] arraytest)
        {
            float result=statistic.Median(arraytest);
            float min = arraytest.Min();
            float max = arraytest.Max();
            Assert.That(result,Is.InRange(min, max));
        }

        [Test]
        [TestCase(new float[] { 12, 16, 20, 33, 55, 77 })]
        [TestCase(new float[] { 18, 22, 10, 66, 11, 25 })]
        [TestCase(new float[] { 12, 11, 20, 1, 98, 20 })]
        public void DevationTest(float[] arraytest)
        {
            double result = statistic.Devation(arraytest);
            float min = arraytest.Min();
            float max = arraytest.Max();
            Assert.That(result, Is.LessThan(max-min));
        }

    }
}
