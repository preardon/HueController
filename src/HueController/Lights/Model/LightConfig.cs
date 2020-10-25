using System.Text.Json.Serialization;

namespace PReardon.HueController.Lights.Model
{
    public class LightConfig
    {
        [JsonPropertyName("archetype")]
        public string Archetype { get; set; } //"sultanbulb",
        [JsonPropertyName("function")]
        public string Function { get; set; } //"mixed",
        [JsonPropertyName("direction")]
        public string Direction { get; set; } // "omnidirectional",
        [JsonPropertyName("startup")]
        public LightStartup Startup {get;set;}
    }
}
