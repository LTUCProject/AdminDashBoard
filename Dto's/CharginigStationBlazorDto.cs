using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Admin.Dto_s
{
    public class ChargingStationBlazorDto // Corrected class name
    {
        public int ChargingStationId { get; set; }
        public string StationLocation { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Name { get; set; }
        public bool HasParking { get; set; }
        public string Status { get; set; }
        public string PaymentMethod { get; set; }


        [JsonPropertyName("chargers")]
        public ChargerBlazorWrapper Chargers { get; set; } = new ChargerBlazorWrapper();

        public ProviderBlazorDto Provider { get; set; }
    }

    public class ChargerBlazorDto
    {
        public int ChargerId { get; set; }
        public string Type { get; set; }
        public int Power { get; set; }
        public string Speed { get; set; }

        [JsonPropertyName("chargingStationId")]
        public int ChargingStationId { get; set; }
    }

    public class ProviderBlazorDto
    {
        public int ProviderId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
    }

    public class ProviderBlazorWrapper
    {
        [JsonPropertyName("$values")]
        public List<ProviderBlazorDto> Values { get; set; } = new List<ProviderBlazorDto>();
    }

    public class ChargerBlazorWrapper
    {
        [JsonPropertyName("$values")]
        public List<ChargerBlazorDto> Values { get; set; } = new List<ChargerBlazorDto>();
    }

    public class ChargingStationBlazorWrapper // Corrected class name
    {
        [JsonPropertyName("$values")]
        public List<ChargingStationBlazorDto> Values { get; set; } = new List<ChargingStationBlazorDto>();
    }
}
