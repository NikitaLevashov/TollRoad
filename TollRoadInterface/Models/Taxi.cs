using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollRoad.TransportConstants;
using TollRoadInterface.Interfaces;

namespace TollRoadInterface.Models
{
    public class Taxi : IVehicle
    {
        readonly IPeakTime _peakTime;

        public int Fares { get; set; }

        public Taxi(IPeakTime peakTime)
        {
            _peakTime = peakTime;
        }

        public decimal CalculateToll()
        {
            if (Fares == 0)
                return TaxiConstants.BasicToll + TaxiConstants.TollWithoutFares;
            if (Fares == 1)
                return TaxiConstants.BasicToll;
            if (Fares == 2)
                return TaxiConstants.BasicToll + TaxiConstants.TollWithTwoFares;
            else
                return TaxiConstants.BasicToll + TaxiConstants.TollMoreThreeFares;
        }

        public decimal PeakTimeMethod(DateTime time, bool inbound)
        {
            return _peakTime.PeakTime(time, inbound);
        }
    }
}
