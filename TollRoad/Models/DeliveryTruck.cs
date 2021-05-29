using TollRoad.TransportConstants;

namespace TollRoad.Models
{
    /// <summary>
    /// Class <c>DeliveryTruck.</c>
    /// </summary>
    public class DeliveryTruck : Transport
    {
        public int GrossWeightClass { get; set; }

        public DeliveryTruck(decimal tarif, int grossWeightClass) : base(tarif)
        {
            GrossWeightClass = grossWeightClass;
        }

        /// <summary>
        /// Method override Calculate
        /// </summary>
        /// <returns>Road toll.</returns>
        public override decimal Calculate()
        {
            return GrossWeightClass switch
            {
                > DeliveryTruckConstants.GrossWeightClass => Tarif + DeliveryTruckConstants.TollMoreGrossWeight,
                < DeliveryTruckConstants.SmallGrossWeightClass => Tarif + DeliveryTruckConstants.TollLessSmallGrossWeight,
                _ => Tarif
            };
        }
    }
}
