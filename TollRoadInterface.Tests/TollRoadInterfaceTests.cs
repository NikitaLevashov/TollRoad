using Moq;
using NUnit.Framework;
using System;
using TollRoad.TransportConstants;
using TollRoadInterface.Interfaces;
using TollRoadInterface.Repository;

namespace TollRoadInterface.Tests
{
    public class Tests
    {
        /// <summary>
        /// For project TollRoadInterface.
        /// </summary>
        [Test]
        public void CreateBusOnceTime()
        {
            Mock<IVehicle> mock = new Mock<IVehicle>();

            mock.Setup(provider => provider.CalculateToll())
                .Returns(() => new TollRoadInterface.Models.Bus(new PeakTimePremiumFullRepository()).CalculateToll());

            Mock<IPeakTime> mockPeakTime = new Mock<IPeakTime>();
            IPeakTime peakTimeValue = mockPeakTime.Object;

            var transformer = new Models.Bus(peakTimeValue);

            transformer.CalculateToll();

            mock.Verify();
        }


        /// <summary>
        /// For project TollRoadInterface.
        /// </summary>
        [Test]
        public void Test_Getting_Mock_By_The_Mocked_CalculateColl_Verify()
        {
            Mock<IVehicle> mock = new Mock<IVehicle>();

            mock.Setup(ld => ld.CalculateToll());

            IVehicle item = mock.Object;

            item.CalculateToll();

            mock.Verify(pro => pro.CalculateToll(), Times.Once());
        }

        /// <summary>
        /// For project TollRoadInterface.
        /// </summary>
        [Test]
        public void Test_Getting_Mock_By_The_Mocked_PeakTime_Verify()
        {
            Mock<IPeakTime> mock = new Mock<IPeakTime>();

            mock.Setup(ld => ld.PeakTime(new DateTime(2020, 12, 12), true));

            IPeakTime item = mock.Object;

            item.PeakTime(new DateTime(2020, 12, 12), true);

            mock.Verify(pro => pro.PeakTime(new DateTime(2020, 12, 12), true), Times.Once());
        }


        /// <summary>
        /// For project TollRoadInterface.
        /// </summary>
        [Test]
        [TestCase(0, ExpectedResult = 2.5)]
        [TestCase(1, ExpectedResult = 2)]
        [TestCase(2, ExpectedResult = 1.5)]
        [TestCase(3, ExpectedResult = 1.0)]
        [TestCase(4, ExpectedResult = 1.0)]
        public decimal Test_Getting_Mock_By_The_Mocked_AssertCalculateTest(int passengers)
        {
             IVehicle mock =
                Mock.Of<IVehicle>(d => d.CalculateToll() == CalculateTest(passengers));

   
            var current = mock.CalculateToll();
            return current;
        }

        private decimal CalculateTest(int passengers) => passengers switch
        {
            0 => 2.00m + CarConstants.TollWithoutPassengers,
            1 => 2.00m,
            2 => 2.00m + CarConstants.TollWithTwoPassenger,
            _ => 2.00m + CarConstants.TollMoreThreePassenger
        };
    }
}