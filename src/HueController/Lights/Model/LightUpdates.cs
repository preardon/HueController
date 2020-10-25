using System;
using System.Text.Json.Serialization;

namespace PReardon.HueController.Lights.Model
{
    public class LightUpdates
    {
        [JsonPropertyName("state")]
        public string State { get; set; } // "noupdates",
        [JsonPropertyName("lastinstall")]
        public DateTime LastInstall { get; set; }
    }
}
