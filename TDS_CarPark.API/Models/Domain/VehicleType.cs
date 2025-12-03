namespace TDS_CarPark.API.Models.Domain
{
    public class VehicleType
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
    }
}
