using EquipmentRental.Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace EquipmentRental.Data
{
    public class EquipmentRentalContext : DbContext
    {
        public EquipmentRentalContext(DbContextOptions<EquipmentRentalContext> options)
    :   base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rental>().HasKey(sc => new { sc.CustomerId, sc.EquipmentId });

            modelBuilder.Entity<Equipment>().HasData(new Equipment { EquipmentId = 1, Name = "Caterpillar bulldozer", Type = EquipmentType.Heavy },
                                                        new Equipment { EquipmentId = 2, Name = "KamAZ truck", Type = EquipmentType.Regular },
                                                        new Equipment { EquipmentId = 3, Name = "Komatsu crane", Type = EquipmentType.Heavy },
                                                        new Equipment { EquipmentId = 4, Name = "Volvo steamroller", Type = EquipmentType.Regular },
                                                        new Equipment { EquipmentId = 5, Name = "Bosch jackhammer", Type = EquipmentType.Specialized }
                );

            modelBuilder.Entity<Customer>().HasData(new Customer { CustomerId = 1, Name = "Test Customer" });
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Rental> Rentals { get; set; }
    }
}
