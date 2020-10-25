using System.Text.Json.Serialization;

namespace PReardon.HueController.Lights.Model
{
    public class LightCapabilitiesStreaming
    {
        [JsonPropertyName("renderer")]
        public bool Renderer { get; set; }
        [JsonPropertyName("proxy")]
        public bool Proxy { get; set; }
}
}
