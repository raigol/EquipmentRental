using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EquipmentRental.Data.Domain
{
    public class Equipment
    {
        public int EquipmentId { get; set; }

        public EquipmentType Type { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public IList<Rental> Rentals { get; set; }
    }
}
