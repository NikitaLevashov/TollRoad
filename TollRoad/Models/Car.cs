using TollRoad.TransportConstants;

namespace TollRoad.Models
{
    public class Car : Transport
    {
        public Car(decimal tarif, int passangers) : base(passangers)
        {
            Passengers = passangers;
        }

        public int Passengers { get; set; }

        /// <summary>
        /// Method override Calculate.
        /// </summary>
        /// <returns>Road toll.</returns>
        public override decimal Calculate() => Passengers switch
        {
            0 => Tarif + CarConstants.TollWithoutPassengers,
            1 => Tarif,
            2 => Tarif + CarConstants.TollWithTwoPassenger,
            _ => Tarif + CarConstants.TollMoreThreePassenger
        };
    }
}
