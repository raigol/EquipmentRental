using EquipmentRental.Api.Services;
using EquipmentRental.Data.Domain;
using Xunit;

namespace EquipmentRental.Tests
{
    public class OrderPriceTests
    {
        private readonly PriceService _priceService;
       

        public OrderPriceTests()
        {            
            _priceService = new PriceService();
            
        }

        [Fact]
        public void CalculateHeavyEquipmentRowPrice()
        {
           int days = 5;
           decimal price = _priceService.CalculatePrice(EquipmentType.Heavy, days);

            Assert.Equal(400, price);
        }


        [Fact]
        public void CalculateSpecializedEquipmentRowPrice()
        {
            int days = 5;
            decimal price = _priceService.CalculatePrice(EquipmentType.Specialized, days);

            Assert.Equal(260, price);
        }

    }
}
