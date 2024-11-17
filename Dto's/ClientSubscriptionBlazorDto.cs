using System.Text.Json.Serialization;
using System;

namespace Admin.Dto_s
{
    public class ClientSubscriptionBlazorDto
    {
        public int ClientSubscriptionId { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; internal set; }
        public string SubscriptionPlanName { get; set; }
        public string SubscriptionPlanDescription { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
    }

    public class ClientSubscriptionBlazorWrapper
    {
        [JsonPropertyName("$values")]
        public List<ClientSubscriptionBlazorDto> Values { get; set; }
    }
}
