using NUnit.Framework;

namespace TollRoad.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [TestCase(2, 2, ExpectedResult = 4)]
        public int Sum(int a, int b) =>
           new Transport().Sum(a, b);
    }
}