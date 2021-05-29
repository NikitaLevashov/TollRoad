using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollRoad.TransportConstants
{
    /// <summary>
    /// Constants for class Bus.
    /// </summary>
    public static class BusConstants
    {
        public const decimal BasicToll = 5.00m;
        public const double ConstLessHalf = 0.50;
        public const double ConstMoreNinetyPercent = 0.90;
        public const decimal RidesByCapasityLessConstLessHalf = 2.00m;
        public const decimal RidesByCapasityMoreConstLessNinetyPercent = -1.00m;
    }
}
