using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollRoad.TransportConstants
{
    /// <summary>
    /// Constants for class Delivery.
    /// </summary>
    public static class DeliveryTruckConstants
    {
        public const decimal BasicToll = 10.00m;
        public const int GrossWeightClass = 5000;
        public const int SmallGrossWeightClass = 3000;
        public const decimal TollMoreGrossWeight = 5.00m;
        public const decimal TollLessSmallGrossWeight = -2.00m;
    }
}
