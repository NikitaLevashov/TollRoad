using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollRoad.TransportConstants;
using TollRoadInterface.Interfaces;

namespace TollRoadInterface.Models
{
    public class Car : IVehicle
    {
        public int Passengers { get; set; }

        IPeakTime _pikeTime;

        public Car(IPeakTime pikeTime)
        {
            _pikeTime = pikeTime;
        }

        public decimal CalculateToll()
        {
            if (Passengers == 0)
                return CarConstants.BasicToll + CarConstants.TollWithoutPassengers;
            if (Passengers == 1)
                return CarConstants.BasicToll;
            if (Passengers == 2)
                return CarConstants.BasicToll + CarConstants.TollWithTwoPassenger;
            else
                return CarConstants.BasicToll - CarConstants.TollMoreThreePassenger;
        }

        public decimal PeakTimeMethod(DateTime time, bool inbound)
        {
            return _pikeTime.PeakTime(time, inbound);
        }

    }
}
