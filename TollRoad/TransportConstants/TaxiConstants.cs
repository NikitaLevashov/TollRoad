using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollRoad.TransportConstants
{
    /// <summary>
    /// Constants for class Taxi.
    /// </summary>
    public static class TaxiConstants
    {
        public const decimal BasicToll = 3.50m;
        public const decimal TollWithoutFares = 1.00m;
        public const decimal TollWiOneFares = 0.00m;
        public const decimal TollWithTwoFares = -0.50m;
        public const decimal TollMoreThreeFares = -1.00m;
    }
}
