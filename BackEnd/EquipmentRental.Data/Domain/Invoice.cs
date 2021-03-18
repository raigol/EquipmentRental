using System.Collections.Generic;

namespace EquipmentRental.Data.Domain
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public decimal InvoiceSum { get; set; }
        public int LoyaltyPoints { get; set; }
        public IList<InvoiceRow> InvoiceRows { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
