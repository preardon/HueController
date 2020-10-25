using System.Text.Json.Serialization;

namespace PReardon.HueController.Groups.Model
{
    public class Group
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("lights")]
        public string[] Lights { get; set; }

        [JsonPropertyName("type")]
        public GroupType Type { get; set; }

        [JsonPropertyName("action")]
        public GroupActionBase Action { get; set; }
    }
}
