using EquipmentRental.Data.Domain;
using System.Collections.Generic;
using System.Linq;

namespace EquipmentRental.Data.Repository
{
    public class EquipmentRepository
    {
        private readonly EquipmentRentalContext _context;
        public EquipmentRepository(EquipmentRentalContext context)
        {
            _context = context;
        }


        public IEnumerable<Equipment> GetEquipments()
        {
            return  _context.Equipments;
        }

        public IEnumerable<Equipment> GetEquipmentsByIds(List<int> equipmentIds)
        {
            return _context.Equipments.Where(p => equipmentIds.Contains(p.EquipmentId));
        }

        public Equipment GetEquipmentById(int equipmentId)
        {
            return _context.Equipments.Where(p => p.EquipmentId == equipmentId).FirstOrDefault();
        }
    }
}
