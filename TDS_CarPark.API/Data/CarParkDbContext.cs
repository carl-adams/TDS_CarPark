using Microsoft.EntityFrameworkCore;
using TDS_CarPark.API.Models.Domain;

namespace TDS_CarPark.API.Data
{
    public class CarParkDbContext : DbContext
    {
        public CarParkDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
                
        }

        public DbSet<Space> Space { get; set; }
        public DbSet<VehicleType> VehicleType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Explicit GUIDs so HasData becomes deterministic and migratable
            var vehicleTypeOne = Guid.Parse("a1d4f2e8-0001-4b8a-9b12-111111111111");
            var vehicleTypeTwo = Guid.Parse("a1d4f2e8-0002-4b8a-9b12-222222222222");
            var vehicleTypeThree = Guid.Parse("a1d4f2e8-0003-4b8a-9b12-333333333333");

            var spaceOne = Guid.Parse("a1d4f2e8-1001-4b8a-9b12-444444444441");
            var spaceTwo = Guid.Parse("a1d4f2e8-1002-4b8a-9b12-444444444442");
            var spaceThree = Guid.Parse("a1d4f2e8-1003-4b8a-9b12-444444444443");
            var spaceFour = Guid.Parse("a1d4f2e8-1004-4b8a-9b12-444444444444");
            var spaceFive = Guid.Parse("a1d4f2e8-1005-4b8a-9b12-444444444445");
            var spaceSix = Guid.Parse("a1d4f2e8-1006-4b8a-9b12-444444444446");
            var spaceSeven = Guid.Parse("a1d4f2e8-1007-4b8a-9b12-444444444447");
            var spaceEight = Guid.Parse("a1d4f2e8-1008-4b8a-9b12-444444444448");
            var spaceNine = Guid.Parse("a1d4f2e8-1009-4b8a-9b12-444444444449");

            modelBuilder.Entity<VehicleType>().HasData(
                new VehicleType { Id = vehicleTypeOne, Number = 1, Name = "Small Car", Cost = 0.10 },
                new VehicleType { Id = vehicleTypeTwo, Number = 2, Name = "Medium Car", Cost = 0.20 },
                new VehicleType { Id = vehicleTypeThree, Number = 3, Name = "Large Car", Cost = 0.40 }
            );

            modelBuilder.Entity<Space>().HasData(
                new Space { Id = spaceOne, SpaceNumber = 1, IsOccupied = false, VehicleReg = null, VehicleTypeId = null, TimeIn = null },
                new Space { Id = spaceTwo, SpaceNumber = 2, IsOccupied = false, VehicleReg = null, VehicleTypeId = null, TimeIn = null },
                new Space { Id = spaceThree, SpaceNumber = 3, IsOccupied = false, VehicleReg = null, VehicleTypeId = null, TimeIn = null },
                new Space { Id = spaceFour, SpaceNumber = 4, IsOccupied = false, VehicleReg = null, VehicleTypeId = null, TimeIn = null },
                new Space { Id = spaceFive, SpaceNumber = 5, IsOccupied = false, VehicleReg = null, VehicleTypeId = null, TimeIn = null },
                new Space { Id = spaceSix, SpaceNumber = 6, IsOccupied = false, VehicleReg = null, VehicleTypeId = null, TimeIn = null },
                new Space { Id = spaceSeven, SpaceNumber = 7, IsOccupied = false, VehicleReg = null, VehicleTypeId = null, TimeIn = null },
                new Space { Id = spaceEight, SpaceNumber = 8, IsOccupied = false, VehicleReg = null, VehicleTypeId = null, TimeIn = null },
                new Space { Id = spaceNine, SpaceNumber = 9, IsOccupied = false, VehicleReg = null, VehicleTypeId = null, TimeIn = null }
            );
        }
    }
}
