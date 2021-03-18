namespace EquipmentRental.Data.Domain
{
    public class InvoiceRow
    {
        public int InvoiceRowId { get; set; }
        public int InvoiceId { get; set; }
        public string Equipment { get; set; }
        public decimal RowSum { get; set; }
                
        public Invoice Invoice { get; set; }
    }
}
