using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EquipmentRental.Data.Domain
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public IList<Rental> Rentals { get; set; }

        public IList<Invoice> Invoices { get; set; }
    }
}
