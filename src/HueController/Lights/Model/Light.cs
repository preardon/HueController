using System.Text.Json.Serialization;

namespace PReardon.HueController.Lights.Model
{
    public class Light : LightBase
    {
        [JsonPropertyName("swupdate")]
        public LightUpdates Swupdate { get; set; }
        [JsonPropertyName("productname")]
        public string ProductName { get; set; }
        [JsonPropertyName("capabilities")]
        public LightCapabilities Capabilities { get; set; }
        [JsonPropertyName("config")]
        public LightConfig Config { get; set; }
        [JsonPropertyName("swconfigid")]
        public string SwConfigId { get; set; } // "772B0E5E",
        [JsonPropertyName("productid")]
        public string ProductId { get; set; } // "Philips-LCT015-1-A19ECLv5"
    }
}
