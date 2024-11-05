using System.Text.Json.Serialization;

namespace Admin.Dto_s
{
    public class NotificationBlazorDto
    {
        public int NotificationId { get; set; }
        public int ClientId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }

    public class NotificationBlazorWrapper
    {
        [JsonPropertyName("$values")]
        public List<NotificationBlazorDto> Values { get; set; }
    }

}
