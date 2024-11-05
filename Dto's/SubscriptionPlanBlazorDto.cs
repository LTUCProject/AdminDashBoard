using System.Text.Json.Serialization;

namespace Admin.Dto_s
{
    public class SubscriptionPlanBlazorDto
    {
        public int SubscriptionPlanId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int DurationInDays { get; set; }
    }

    public class SubscriptionPlanWrapper
    {
        [JsonPropertyName("$values")]
        public List<SubscriptionPlanBlazorDto> Values { get; set; }
    }
}
