using System.Text.Json.Serialization;

namespace PReardon.HueController.Groups.Model
{
    public class CreateGroupResponseItem
    {
        [JsonPropertyName("success")]
        public SuccessResponse Success { get; set; }
    }

    public class SuccessResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}
