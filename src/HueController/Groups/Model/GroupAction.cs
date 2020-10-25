using System.Text.Json.Serialization;

namespace PReardon.HueController.Groups.Model
{
    public class GroupAction : GroupActionBase
    {
        [JsonPropertyName("colormode")]
        public string ColourMode { get; set; }
    }
}
