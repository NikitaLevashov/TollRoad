using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollRoad.TransportConstants;
using TollRoadInterface.Interfaces;

namespace TollRoadInterface.Models
{
    public class DeliveryTruck : IVehicle
    {
        IPeakTime _peakTime;

        public int GrossWeightClass { get; set; }

        public DeliveryTruck(IPeakTime peakTime)
        {
            _peakTime = peakTime;
        }

        public decimal CalculateToll()
        {
            if (GrossWeightClass > DeliveryTruckConstants.GrossWeightClass)
                return DeliveryTruckConstants.BasicToll + DeliveryTruckConstants.TollMoreGrossWeight;
            if (GrossWeightClass < DeliveryTruckConstants.SmallGrossWeightClass)
                return DeliveryTruckConstants.BasicToll + DeliveryTruckConstants.TollLessSmallGrossWeight;
            else
                return DeliveryTruckConstants.BasicToll;
        }

        public decimal PeakTimeMethod(DateTime time, bool inbound)
        {
            return _peakTime.PeakTime(time, inbound);
        }
    }
}
