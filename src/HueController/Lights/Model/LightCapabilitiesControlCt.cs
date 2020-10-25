using System.Text.Json.Serialization;

namespace PReardon.HueController.Lights.Model
{
    public class LightCapabilitiesControlCt
    {
        [JsonPropertyName("min")]
        public int Min { get; set; }
        [JsonPropertyName("max")]
        public int Max { get; set; }
    }
}
