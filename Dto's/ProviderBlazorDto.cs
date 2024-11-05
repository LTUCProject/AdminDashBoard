using System.Text.Json.Serialization;

namespace Admin.Dto_s
{
    public class AllProviderBlazorDto
    {
        public int ProviderId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
    }

    public class AllProviderBlazorWrapper
    {
        [JsonPropertyName("$values")]
        public List<AllProviderBlazorDto> Values { get; set; }
    }
}
