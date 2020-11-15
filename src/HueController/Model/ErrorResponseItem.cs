using System.Text.Json.Serialization;

namespace PReardon.HueController.Model
{
    public class ErrorResponseItem
    {
        [JsonPropertyName("type")]
        public int Type { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
