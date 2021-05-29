using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollRoad.TransportConstants
{
    /// <summary>
    /// Constants for class Car.
    /// </summary>
    public static class CarConstants
    {
        public const decimal BasicToll = 2.00m;
        public const decimal TollWithoutPassengers = 0.50m;
        public const decimal TollWithOnePassenger = 0.0m;
        public const decimal TollWithTwoPassenger = -0.5m;
        public const decimal TollMoreThreePassenger = -1.0m;

    }
}
