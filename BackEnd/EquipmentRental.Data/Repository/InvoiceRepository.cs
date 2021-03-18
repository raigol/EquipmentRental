using EquipmentRental.Data.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EquipmentRental.Data.Repository
{
    public class InvoiceRepository
    {
        private readonly EquipmentRentalContext _context;
        public InvoiceRepository(EquipmentRentalContext context)
        {
            _context = context;
        }


        public IEnumerable<Invoice> GetCustomerInvoices(int customerId)
        {
            return _context.Invoices.Where(p => p.CustomerId == customerId).OrderBy(i => i.InvoiceId);
        }

        public int GetCustomerLoyaltyPoints(int customerId)
        {
            return _context.Invoices.Where(p => p.CustomerId == customerId).Select(x => x.LoyaltyPoints).Sum();
        }

        public Invoice GetInvoiceDetails(int invoiceId)
        {
            return _context.Invoices
                .Include(i => i.InvoiceRows)
                .Where(p => p.InvoiceId == invoiceId).FirstOrDefault();
        }

        public Invoice CreateInvoice(Invoice invoice)
        {
            invoice.Customer = _context.Customers.Find(1);
            
           _context.Invoices.Add(invoice);
           _context.SaveChanges();
           return invoice;

        }

    }
}
