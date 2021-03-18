using System.Collections.Generic;

namespace EquipmentRental.Api.Dto
{
    public class InvoiceDetailDto
    {
        public int InvoiceId { get; set; }
        public decimal InvoiceSum { get; set; }
        public int LoyaltyPoints { get; set; }

        public List<InvoiceRowDto> InvoiceRows { get; set; }
    }
}
