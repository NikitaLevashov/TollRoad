using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollRoad.Models;
using TollRoad.TransportConstants;

namespace TollRoad.Tests
{
    public sealed class TestCasesSource
    {
        public static IEnumerable<TestCaseData> TestCases
        {
            get
            {
                yield return new TestCaseData(new Car(CarConstants.BasicToll, 1), new DateTime(2021, 12, 12), true).Returns(2);
                yield return new TestCaseData(new Car(CarConstants.BasicToll, 2), new DateTime(2021, 12, 12), false).Returns(2.5);
                yield return new TestCaseData(new Car(CarConstants.BasicToll, 3), new DateTime(2021, 12, 12), false).Returns(3.0);
                yield return new TestCaseData(new Car(CarConstants.BasicToll, 0), new DateTime(2021, 12, 12), true).Returns(1.5);

                yield return new TestCaseData(new Taxi(TaxiConstants.BasicToll, 1), new DateTime(2021, 12, 12), true).Returns(4.5);
                yield return new TestCaseData(new Taxi(TaxiConstants.BasicToll, 2), new DateTime(2021, 12, 12), false).Returns(3.5);
                yield return new TestCaseData(new Taxi(TaxiConstants.BasicToll, 3), new DateTime(2021, 12, 12), false).Returns(4.0);
                yield return new TestCaseData(new Taxi(TaxiConstants.BasicToll, 0), new DateTime(2021, 12, 12), true).Returns(5.5);

                yield return new TestCaseData(new Bus(BusConstants.BasicToll, 12, 20), new DateTime(2021, 12, 12), true).Returns(5.0);
                yield return new TestCaseData(new Bus(BusConstants.BasicToll, 13, 40), new DateTime(2021, 12, 12), false).Returns(5.0);
                yield return new TestCaseData(new Bus(BusConstants.BasicToll, 10, 30), new DateTime(2021, 12, 12), false).Returns(5.0);
                yield return new TestCaseData(new Bus(BusConstants.BasicToll, 10, 20), new DateTime(2021, 12, 12), true).Returns(5.0);

                yield return new TestCaseData(new DeliveryTruck(DeliveryTruckConstants.BasicToll, 2500), new DateTime(2021, 12, 12), true).Returns(9);
                yield return new TestCaseData(new DeliveryTruck(DeliveryTruckConstants.BasicToll, 5000), new DateTime(2021, 12, 12), false).Returns(11);
                yield return new TestCaseData(new DeliveryTruck(DeliveryTruckConstants.BasicToll, 6000), new DateTime(2021, 12, 12), false).Returns(16);
                yield return new TestCaseData(new DeliveryTruck(DeliveryTruckConstants.BasicToll, 1000), new DateTime(2021, 12, 12), true).Returns(9);
            }
        }
    }
}
