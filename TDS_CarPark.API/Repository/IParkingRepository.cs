using TDS_CarPark.API.Models.Domain;
using TDS_CarPark.API.Models.DTO;

namespace TDS_CarPark.API.Repository
{
    public interface IParkingRepository
    {
        Task<int> GetAvailableSpacesCountAsync();
        Task<int> GetOccupiedSpacesCountAsync();
        Task<Space> VehicleParkAsync(ParkingRequestDto parkingRequestDto);
        Task<ParkingExistResultDto> VehicleExitAsync(ParkingExitRequestDto parkingExitRequestDto);
    }
}
