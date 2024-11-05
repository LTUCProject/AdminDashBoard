using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Admin.Dto_s
{
    public class ClientBlazorDto
    {
        public int ClientId { get; set; } // Ensure this matches the JSON property
        public string Name { get; set; }
        public string Email { get; set; }
        public string AccountId { get; set; }
    }


public class ClientBlazorWrapper
    {
        [JsonPropertyName("$values")]
        public List<ClientBlazorDto> Values { get; set; }
    }

}
