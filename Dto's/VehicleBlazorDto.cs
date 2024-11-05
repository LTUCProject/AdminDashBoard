using System.Text.Json.Serialization;

namespace Admin.Dto_s
{
    public class VehicleBlazorDto
    {
        public int VehicleId { get; set; }
        public string LicensePlate { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int BatteryCapacity { get; set; }
        public string ElectricType { get; set; }
        public int ClientId { get; set; }
    }
    public class VehicleBlazorWrapper
    {
        [JsonPropertyName("$values")]
        public List<VehicleBlazorDto> Values { get; set; }
    }
}
