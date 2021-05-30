using Moq;
using NUnit.Framework;
using System;
using TollRoad.Models;
using TollRoad.TransportConstants;

using Moq.Protected;

namespace TollRoad.Tests
{
    public class Tests
    {
        /// <summary>
        /// For project TollRoad(abstract).
        /// </summary>
        [Test]
        [TestCaseSource(typeof(TestCasesSource), nameof(TestCasesSource.TestCases))]
        public decimal CalculateToll_WithCorrectParameters_ReturnDecimal(Transport transport, DateTime dateTime, bool inbound) =>
            transport.CalculateToll(dateTime, inbound);

        [Test]
        public void TransportBehaviorTest()
        {
            Mock<Transport> mock = new Mock<Transport>(null);

            mock.Setup(ld => ld.Calculate());

            Transport item = mock.Object;

            item.CalculateToll(new DateTime(2012,12,12),true);

            mock.Verify(pro => pro.Calculate(), Times.Once());
                        
        }

        [TestCase(0, ExpectedResult = 4.5)]
        [TestCase(1, ExpectedResult = 3.5)]
        [TestCase(2,  ExpectedResult = 2.5)]
        [TestCase(3, ExpectedResult = 3.0)]
        [TestCase(4, ExpectedResult = 2.5)]
        public decimal TransportTestCalculate(int fares)
        {
            Mock<Transport> mock = new Mock<Transport>(null);

            mock.Setup(ld =>ld.Calculate()).Returns(CalculateTestTaxi(fares));

            Transport item = mock.Object;

            var result = item.Calculate();

            return result;

            Assert.That(result, Is.EqualTo(3.5m));
        }

        public decimal CalculateTestTaxi(int fares) => fares switch
        {
            0 => 3.50m + TaxiConstants.TollWithoutFares,
            1 => 3.50m,
            3 => 3.50m + TaxiConstants.TollWithTwoFares,
            _ => 3.50m + TaxiConstants.TollMoreThreeFares
        };


    }
}