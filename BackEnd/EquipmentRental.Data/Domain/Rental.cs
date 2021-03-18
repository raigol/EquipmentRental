namespace EquipmentRental.Data.Domain
{
    public class Rental
    {
        public int RentalId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; }
    }
}
