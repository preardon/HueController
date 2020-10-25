using System.Text.Json.Serialization;

namespace PReardon.HueController.Lights.Model
{
    public class LightStartup
    {
        [JsonPropertyName("mode")]
        public string Mode { get; set; } //"safety",
        [JsonPropertyName("configured")]
        public bool Configured { get; set; }
    }
}
