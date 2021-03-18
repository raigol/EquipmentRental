using EquipmentRental.Api.Services;
using EquipmentRental.Data.Domain;
using Xunit;

namespace EquipmentRental.Tests
{
    public class OrderPriceTests
    {
        private readonly OrderService _orderService;
        
        public OrderPriceTests()
        {
            _orderService = new OrderService();
            
        }

        [Fact]
        public void CalculateHeavyEquipmentRowPrice()
        {
           int days = 5;
           decimal price = _orderService.CalculatePrice(EquipmentType.Heavy, days);

            Assert.Equal(400, price);
        }


        [Fact]
        public void CalculateSpecializedEquipmentRowPrice()
        {
            int days = 5;
            decimal price = _orderService.CalculatePrice(EquipmentType.Specialized, days);

            Assert.Equal(260, price);
        }

    }
}
