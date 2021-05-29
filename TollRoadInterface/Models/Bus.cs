using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollRoad.TransportConstants;
using TollRoadInterface.Interfaces;

namespace TollRoadInterface.Models
{
    public class Bus : IVehicle
    {
        public int Capacity { get; set; }
        public int Riders { get; set; }

        IPeakTime _pikeTime;

        public Bus(IPeakTime pikeTime)
        {
            _pikeTime = pikeTime;
        }

        public decimal CalculateToll()
        {
            if (((double)Riders / (double)Capacity) < BusConstants.ConstLessHalf)
                return BusConstants.BasicToll + BusConstants.RidesByCapasityLessConstLessHalf;
            if (((double)Riders / (double)Capacity) > BusConstants.ConstMoreNinetyPercent)
                return BusConstants.BasicToll + BusConstants.RidesByCapasityMoreConstLessNinetyPercent;
            else return BusConstants.BasicToll;
        }

        public decimal PeakTimeMethod(DateTime time, bool inbound)
        {
            return _pikeTime.PeakTime(time, inbound);
        }
    }
}
