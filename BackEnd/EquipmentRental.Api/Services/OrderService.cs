using EquipmentRental.Api.Dto;
using EquipmentRental.Data;
using EquipmentRental.Data.Domain;
using EquipmentRental.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Tests")]
namespace EquipmentRental.Api.Services
{
    public class OrderService
    {
        private readonly EquipmentRepository _equipmentRepository;
        private readonly InvoiceRepository _invoiceRepository;
        private readonly EquipmentRentalContext _equipmentRentalContext;
       

        public OrderService()
        {
            _equipmentRentalContext = new EquipmentRentalContext();
            _equipmentRepository = new EquipmentRepository(_equipmentRentalContext);
            _invoiceRepository = new InvoiceRepository(_equipmentRentalContext);
        }

        public Invoice ProcessOrder(List<OrderItemDto> orders)
        {
            IEnumerable<Equipment> products = _equipmentRepository.GetEquipmentsByIds(orders.Select(l => l.EquipmentId).ToList());

            decimal totalFee = 0;
            int totalLoyaltyPoints = 0;
            List<InvoiceRow> invoiceRows = new List<InvoiceRow>();

            foreach (var order in orders)
            {
                Equipment equipment = products.Where(p => p.EquipmentId == order.EquipmentId).FirstOrDefault();
                decimal rowFee = CalculatePrice(equipment.Type, order.Quantity);
                totalFee += rowFee;
                totalLoyaltyPoints += CalculateLoyaltyPoints(equipment.Type);
                invoiceRows.Add(new InvoiceRow { Equipment = equipment.Name, RowSum = rowFee });
            }

            Invoice invoice = new Invoice{ InvoiceSum = totalFee, LoyaltyPoints = totalLoyaltyPoints  };
            invoice.InvoiceRows = invoiceRows;
            return _invoiceRepository.CreateInvoice(invoice);

        }

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

        private int CalculateLoyaltyPoints(EquipmentType equipmentType)
        {
            switch (equipmentType)
            {
                case EquipmentType.Heavy:
                    return 2;

                default:
                    return 1;
            }
        }
    }
}
