using Microsoft.EntityFrameworkCore;
using System;
using TDS_CarPark.API.Data;
using TDS_CarPark.API.Models.Domain;
using TDS_CarPark.API.Models.DTO;

namespace TDS_CarPark.API.Repository
{
    public class SQLParkingRepository : IParkingRepository
    {
        private CarParkDbContext dbContext;

        public SQLParkingRepository(CarParkDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> GetAvailableSpacesCountAsync()
        {
            var availableSpacesList = await dbContext.Space
                .Where(s => !s.IsOccupied)
                .ToListAsync();

            return availableSpacesList.Count;
        }

        public async Task<int> GetOccupiedSpacesCountAsync()
        {
            var occupiedSpacesList = await dbContext.Space
                .Where(s => s.IsOccupied)
                .ToListAsync();

            return occupiedSpacesList.Count;
        }

        public async Task<Space> VehicleParkAsync(ParkingRequestDto parkingRequestDto)
        {
            var vehicleRegUsed = await dbContext.Space
                .Where(s => s.VehicleReg.Contains(parkingRequestDto.VehicleReg.Replace(" ", "")))
                .FirstOrDefaultAsync();

            if(vehicleRegUsed != null)
            {
                return null;
            }

            var firstAvailableSpace = await dbContext.Space
                .Where(s => !s.IsOccupied)
                .OrderBy(s => s.SpaceNumber)
                .FirstOrDefaultAsync();

            if (firstAvailableSpace == null)
            {
                return null;
            }

            var vehicleType = await dbContext.VehicleType
                .FirstOrDefaultAsync(vt => vt.Number == parkingRequestDto.VehicleType);

            if (vehicleType == null)
            {
                return null;
            }

            firstAvailableSpace.IsOccupied = true;
            firstAvailableSpace.VehicleReg = parkingRequestDto.VehicleReg.Replace(" ", "");
            firstAvailableSpace.VehicleTypeId = vehicleType.Id;
            firstAvailableSpace.VehicleType = vehicleType;
            firstAvailableSpace.TimeIn = DateTime.UtcNow;

            await dbContext.SaveChangesAsync();

            return firstAvailableSpace;
        }

        public async Task<ParkingExistResultDto> VehicleExitAsync(ParkingExitRequestDto parkingExitRequestDto)
        {
            var spaceTaken = await dbContext.Space
                .Where(s => s.VehicleReg.Contains(parkingExitRequestDto.VehicleReg.Replace(" ", "")))
                .Where(s => s.IsOccupied)
                .FirstOrDefaultAsync();

            if (spaceTaken == null)
            {
                return null;
            }

            var vehicleType = await dbContext.VehicleType
                .Where(s => s.Id.Equals(spaceTaken.VehicleTypeId))
                .FirstOrDefaultAsync();

            if (vehicleType == null)
            {
                return null;
            }

            var exitTime = DateTime.UtcNow;
            var exitTruncated = new DateTime(exitTime.Year, exitTime.Month, exitTime.Day, exitTime.Hour, exitTime.Minute, 0, DateTimeKind.Utc);

            var timeIn = spaceTaken.TimeIn.Value;
            var timeInTruncated = new DateTime(timeIn.Year, timeIn.Month, timeIn.Day, timeIn.Hour, timeIn.Minute, 0, DateTimeKind.Utc);

            var timeOccupied = exitTruncated - timeInTruncated;
            double totalMinutes = (int)timeOccupied.TotalMinutes;

            int billedMinutes = (int)Math.Floor(totalMinutes);
            int fiveMinuteBlocks = (int)Math.Floor(billedMinutes / 5.0);

            double cost = billedMinutes * vehicleType.Cost;

            double surcharge = fiveMinuteBlocks;
            double totalCost = Math.Round(cost + surcharge, 2);

            var vehicleExit = new ParkingExistResultDto()
            {
                VehicleReg = spaceTaken.VehicleReg,
                VehicleCharge = totalCost,
                TimeIn = spaceTaken.TimeIn.Value,
                TimeOut = exitTime,
            };

            spaceTaken.IsOccupied = false;
            spaceTaken.VehicleReg = null;
            spaceTaken.VehicleTypeId = null;
            spaceTaken.TimeIn = null;

            await dbContext.SaveChangesAsync();

            return vehicleExit;
        }
    }
}
