namespace TDS_CarPark.API.Models.DTO
{
    public class ParkingExistResultDto
    {
        public string VehicleReg { get; set; }
        public double VehicleCharge { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
    }
}
