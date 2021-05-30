using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollRoad.Models
{
    /// <summary>
    /// Class<c>Transport</c>
    /// </summary>
    public abstract class Transport
    {
        public decimal Tarif { get; set; }

        public Transport(decimal tarif)
        {
            Tarif = tarif;
        }

        /// <summary>
        /// Method terurn true or false.
        /// </summary>
        /// <param name="timeOfToll">Data.</param>
        /// <returns>Day off or not.</returns>
        private static bool IsWeekDay(DateTime timeOfToll) =>
           timeOfToll.DayOfWeek switch
           {
               DayOfWeek.Saturday => false,
               DayOfWeek.Sunday => false,
               _ => true
           };

        private enum TimeBand
        {
            MorningRush,
            Daytime,
            EveningRush,
            Overnight
        }

        /// <summary>
        /// The method returns the time of day.
        /// </summary>
        /// <param name="timeOfToll">Data.</param>
        /// <returns></returns>
        private static TimeBand GetTimeBand(DateTime timeOfToll) =>
            timeOfToll.Hour switch
            {
                < 6 or > 19 => TimeBand.Overnight,
                < 10 => TimeBand.MorningRush,
                < 16 => TimeBand.Daytime,
                _ => TimeBand.EveningRush,
            };

        /// <summary>
        /// Method return road toll for time.
        /// </summary>
        /// <param name="timeOfToll">Data.</param>
        /// <param name="inbound">Direction.</param>
        /// <returns></returns>
        private decimal PeakTime(DateTime timeOfToll, bool inbound) =>
            (IsWeekDay(timeOfToll), GetTimeBand(timeOfToll), inbound) switch
            {
                (true, TimeBand.Overnight, _) => 0.75m,
                (true, TimeBand.Daytime, _) => 1.5m,
                (true, TimeBand.MorningRush, true) => 2.0m,
                (true, TimeBand.EveningRush, false) => 2.0m,
                (_, _, _) => 1.0m,
            };

        /// <summary>
        /// The method returns the full toll. 
        /// </summary>
        /// <param name="dateTime">Data.</param>
        /// <param name="inbound">Direction.</param>
        /// <returns></returns>
        public decimal CalculateToll(DateTime dateTime, bool inbound)
        {
            return PeakTime(dateTime, inbound) + Calculate();
        }

        /// <summary>
        /// The abstract method Caclulate.
        /// </summary>
        /// <returns></returns>
        public abstract decimal Calculate();

    }
}
