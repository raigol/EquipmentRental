namespace EquipmentRental.Api.Dto
{
    public class InvoiceDto
    {
        public int InvoiceId { get; set; }
        public decimal InvoiceSum { get; set; }
        public int LoyaltyPoints { get; set; }
    }
}
