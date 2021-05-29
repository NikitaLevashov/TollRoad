using TollRoad.TransportConstants;

namespace TollRoad.Models
{
    /// <summary>
    /// Class <c>Taxi.</c>
    /// </summary>
    public class Taxi : Transport
    {
        public int Fares { get; set; }

        public Taxi(decimal tarif, int fares) : base(tarif)
        {
            Fares = fares;
        }

        /// <summary>
        /// Method override Calculate.
        /// </summary>
        /// <returns>Road toll.</returns>
        public override decimal Calculate() => Fares switch
        {
            0 => Tarif + TaxiConstants.TollWithoutFares,
            1 => Tarif,
            3 => Tarif + TaxiConstants.TollWithTwoFares,
            _ => Tarif + TaxiConstants.TollMoreThreeFares
        };
    }
}
