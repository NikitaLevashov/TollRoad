using System;
using TollRoadInterface.Models;
using TollRoadInterface.Repository;

namespace TollRoadInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            var soloDriver = new Car(new PeakTimePremiumFullRepository());
            var twoRideShare = new Car(new PeakTimePremiumFullRepository()) { Passengers = 1 };
            var threeRideShare = new Car(new PeakTimePremiumFullRepository()) { Passengers = 2 };
            var fullVan = new Car(new PeakTimePremiumFullRepository()) { Passengers = 5 };
            var emptyTaxi = new Taxi(new PeakTimePremiumRepository());
            var singleFare = new Taxi(new PeakTimePremiumRepository()) { Fares = 1 };
            var doubleFare = new Taxi(new PeakTimePremiumRepository()) { Fares = 2 };
            var fullVanPool = new Taxi(new PeakTimePremiumRepository()) { Fares = 5 };
            var lowOccupantBus = new Bus(new RepositoryPeakTimePremiumIfElseRepository()) { Capacity = 90, Riders = 15 };
            var normalBus = new Bus(new RepositoryPeakTimePremiumIfElseRepository()) { Capacity = 90, Riders = 75 };
            var fullBus = new Bus(new RepositoryPeakTimePremiumIfElseRepository()) { Capacity = 90, Riders = 85 };

            var heavyTruck = new DeliveryTruck(new PeakTimePremiumFullRepository()) { GrossWeightClass = 7500 };
            var truck = new DeliveryTruck(new PeakTimePremiumFullRepository()) { GrossWeightClass = 4000 };
            var lightTruck = new DeliveryTruck(new PeakTimePremiumFullRepository()) { GrossWeightClass = 2500 };

            Console.WriteLine($"The toll for a solo driver is {soloDriver.CalculateToll()}");
            Console.WriteLine($"The toll for a two ride share is {twoRideShare.CalculateToll()}");
            Console.WriteLine($"The toll for a three ride share is {threeRideShare.CalculateToll()}");
            Console.WriteLine($"The toll for a fullVan is {fullVan.CalculateToll()}");

            Console.WriteLine($"The toll for an empty taxi is {emptyTaxi.CalculateToll()}");
            Console.WriteLine($"The toll for a single fare taxi is {singleFare.CalculateToll()}");
            Console.WriteLine($"The toll for a double fare taxi is {doubleFare.CalculateToll()}");
            Console.WriteLine($"The toll for a full van taxi is {fullVanPool.CalculateToll()}");

            Console.WriteLine($"The toll for a low-occupant bus is {lowOccupantBus.CalculateToll()}");
            Console.WriteLine($"The toll for a regular bus is {normalBus.CalculateToll()}");
            Console.WriteLine($"The toll for a bus is {fullBus.CalculateToll()}");

            Console.WriteLine($"The toll for a truck is {heavyTruck.CalculateToll()}");
            Console.WriteLine($"The toll for a truck is {truck.CalculateToll()}");
            Console.WriteLine($"The toll for a truck is {lightTruck.CalculateToll()}");

            Console.WriteLine("====================================================");

            var testTimes = new DateTime[]
            {
                new DateTime(2019, 3, 4, 8, 0, 0), // morning rush
                new DateTime(2019, 3, 6, 11, 30, 0), // daytime
                new DateTime(2019, 3, 7, 17, 15, 0), // evening rush
                new DateTime(2019, 3, 14, 03, 30, 0), // overnight

                new DateTime(2019, 3, 16, 8, 30, 0), // weekend morning rush
                new DateTime(2019, 3, 17, 14, 30, 0), // weekend daytime
                new DateTime(2019, 3, 17, 18, 05, 0), // weekend evening rush
                new DateTime(2019, 3, 16, 01, 30, 0), // weekend overnight
            };

            foreach (var time in testTimes)
            {
                Console.WriteLine($"Inbound premium at {time} is {soloDriver.PeakTimeMethod(time, true)}");
                Console.WriteLine($"Outbound premium at {time} is {soloDriver.PeakTimeMethod(time, false)}");
            }
            Console.WriteLine("====================================================");
            foreach (var time in testTimes)
            {
                Console.WriteLine($"Inbound premium at {time} is {emptyTaxi.PeakTimeMethod(time, true)}");
                Console.WriteLine($"Outbound premium at {time} is {emptyTaxi.PeakTimeMethod(time, false)}");
            }
            Console.WriteLine("====================================================");
            foreach (var time in testTimes)
            {
                Console.WriteLine($"Inbound premium at {time} is {fullBus.PeakTimeMethod(time, true)}");
                Console.WriteLine($"Outbound premium at {time} is {fullBus.PeakTimeMethod(time, false)}");
            }
        }
    }
}
