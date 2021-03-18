using EquipmentRental.Data.Domain;

namespace EquipmentRental.Api.Dto
{
    public class EquipmentDto
    {
        public int EquipmentId { get; set; }
        public EquipmentType Type { get; set; }
        public string Name { get; set; }
    }
}
