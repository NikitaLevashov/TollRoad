using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollRoad.TransportConstants;

namespace TollRoad.Models
{
    /// <summary>
    /// Class <c>Bus.<c>
    /// </summary>
    public class Bus : Transport
    {
        public int Capacity { get; set; }
        public int Riders { get; set; }

        public Bus(decimal tarif, int capacity, int riders) : base(tarif)
        {
            Capacity = capacity;
            Riders = riders;
        }

        /// <summary>
        /// Method override Calculate.
        /// </summary>
        /// <returns>Road toll.</returns>
        public override decimal Calculate()
        {
            var item = (double)Riders / (double)Capacity;
            return item switch
            {
                < BusConstants.ConstLessHalf => Tarif + BusConstants.RidesByCapasityLessConstLessHalf,
                > BusConstants.ConstMoreNinetyPercent => Tarif + BusConstants.RidesByCapasityMoreConstLessNinetyPercent,
                _ => Tarif + BusConstants.RidesByCapasityMoreConstLessNinetyPercent
            };
        }
    }
}
