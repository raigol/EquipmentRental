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
        private readonly PriceService _priceService;


        public OrderService(EquipmentRentalContext context)
        {
            _equipmentRentalContext = context;
            _equipmentRepository = new EquipmentRepository(_equipmentRentalContext);
            _invoiceRepository = new InvoiceRepository(_equipmentRentalContext);
            _priceService = new PriceService();
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
                decimal rowFee = _priceService.CalculatePrice(equipment.Type, order.Quantity);
                totalFee += rowFee;
                totalLoyaltyPoints += CalculateLoyaltyPoints(equipment.Type);
                invoiceRows.Add(new InvoiceRow { Equipment = equipment.Name, RowSum = rowFee });
            }

            Invoice invoice = new Invoice{ InvoiceSum = totalFee, LoyaltyPoints = totalLoyaltyPoints  };
            invoice.InvoiceRows = invoiceRows;
            return _invoiceRepository.CreateInvoice(invoice);

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
