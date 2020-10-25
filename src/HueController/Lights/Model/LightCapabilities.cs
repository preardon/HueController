using System.Text.Json.Serialization;

namespace PReardon.HueController.Lights.Model
{
    public class LightCapabilities
    {
        [JsonPropertyName("certified")]
        public bool Certified { get; set; }
        [JsonPropertyName("control")]
        public LightCapabilitiesControl Control { get; set; }
        [JsonPropertyName("streaming")]
        public LightCapabilitiesStreaming Streaming { get; set; }
    }
}
