namespace TDS_CarPark.API.Models.Domain
{
    public class Space
    {
        public Guid Id { get; set; }
        public int SpaceNumber { get; set; }

        public Boolean IsOccupied { get; set; }

        public string? VehicleReg { get; set; }

        public Guid? VehicleTypeId { get; set; }

        public VehicleType? VehicleType { get; set; }

        public DateTime? TimeIn { get; set; }
    }
}
