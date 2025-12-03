using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TDS_CarPark.API.Data;
using TDS_CarPark.API.Models.DTO;
using TDS_CarPark.API.Repository;

namespace TDS_CarPark.API.Controllers
{
    [Route("parking")]
    [ApiController]
    public class Parking : ControllerBase
    {
        [HttpGet()]
        public async Task<IActionResult> Availability(IParkingRepository parkingRepository)
        {
            int occupiedSpacesList = await parkingRepository.GetOccupiedSpacesCountAsync();
            int availableSpacesList = await parkingRepository.GetAvailableSpacesCountAsync();

            var availabilityDto = new AvailabilityDto()
            {
                AvailableSpaces = availableSpacesList,
                OccupiedSpaces = occupiedSpacesList
            };

            return Ok(availabilityDto);
        }

        [HttpPost()]
        public async Task<IActionResult> VehiclePark([FromBody] ParkingRequestDto parkingRequestDto, IParkingRepository parkingRepository)
        {
            var firstAvailableSpace = await parkingRepository.VehicleParkAsync(parkingRequestDto);

            if (firstAvailableSpace == null)
            {
                return NotFound("Sorry, there are no available parking spaces or your vehicle type was not recognised.");
            }

            var spaceTaken = new ParkingResultDto()
            {
                VehicleReg = firstAvailableSpace.VehicleReg,
                SpaceNumber = firstAvailableSpace.SpaceNumber,
                TimeIn = (DateTime)firstAvailableSpace.TimeIn
            };

            return Ok(spaceTaken);
        }

        [HttpPost()]
        [Route("exit")]
        public async Task<IActionResult> VehicleExit([FromBody] ParkingExitRequestDto parkingExitRequestDto, IParkingRepository parkingRepository)
        {
            var vehicleExit = await parkingRepository.VehicleExitAsync(parkingExitRequestDto);

            if(vehicleExit == null)
            {
                return NotFound("No vehicle with this registration is currently parked in this car park.");
            }

            return Ok(vehicleExit);
        }
    }
}
