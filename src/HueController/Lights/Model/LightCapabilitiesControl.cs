using System.Text.Json.Serialization;

namespace PReardon.HueController.Lights.Model
{
    public class LightCapabilitiesControl
    {
        [JsonPropertyName("mindimlevel")]
        public int MinDimLevel { get; set; }
        [JsonPropertyName("maxlumen")]
        public int MaxLumen { get; set; }
        [JsonPropertyName("colorgamuttype")]
        public string ColourGamutType { get; set; } // "C",
        [JsonPropertyName("colorgamut")]
        public double[][] ColourGamut { get; set; }
        [JsonPropertyName("ct")]
        public LightCapabilitiesControlCt ColourTemperature { get; set; }
    }
}
