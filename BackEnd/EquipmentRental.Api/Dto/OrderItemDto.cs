using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentRental.Api.Dto
{
    public class OrderItemDto
    {

        [Required]
        public int EquipmentId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
