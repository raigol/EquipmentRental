using EquipmentRental.Data.Domain;
using System;

namespace EquipmentRental.Api.Services
{
    public class PriceService
    {
        public decimal CalculatePrice(EquipmentType equipmentType, int days)
        {
            const int oneTimeRentalFee = 100;
            const int premiumDailyFee = 60;
            const int regularDailyFee = 40;

            return equipmentType switch
            {
                EquipmentType.Regular => oneTimeRentalFee + Math.Min(2, days) * premiumDailyFee + (days > 2 ? (days - 2) * regularDailyFee : 0),
                EquipmentType.Heavy => oneTimeRentalFee + days * premiumDailyFee,
                EquipmentType.Specialized => Math.Min(3, days) * premiumDailyFee + (days > 3 ? (days - 3) * regularDailyFee : 0),
                _ => 0,
            };
        }
    }
}
