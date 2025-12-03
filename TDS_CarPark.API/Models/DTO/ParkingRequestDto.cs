using System.ComponentModel.DataAnnotations;

namespace TDS_CarPark.API.Models.DTO
{
    public class ParkingRequestDto
    {
        [Required(ErrorMessage = "VehicleReg field is required.")]
        public string VehicleReg { get; set; }

        [Required(ErrorMessage = "VehicleType field is required.")]
        public int VehicleType { get; set; }
    }
}
