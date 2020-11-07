using System.Text.Json.Serialization;

namespace PReardon.HueController.Groups.Model
{
    public class Group : GroupBase
    {
        [JsonPropertyName("action")]
        public GroupActionBase Action { get; set; }

        [JsonPropertyName("type")]
        public GroupType Type { get; set; }
    }
}
