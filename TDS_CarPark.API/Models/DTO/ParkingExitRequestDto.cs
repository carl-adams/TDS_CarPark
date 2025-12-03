using System.ComponentModel.DataAnnotations;

namespace TDS_CarPark.API.Models.DTO
{
    public class ParkingExitRequestDto
    {
        [Required(ErrorMessage = "VehicleReg field is required.")]
        public string VehicleReg { get; set; }
    }
}
