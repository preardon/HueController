using System.Text.Json.Serialization;

namespace PReardon.HueController.Configuration.Model
{
    public class DeviceTypes
    {

        /// <summary>
        /// Update available for the bridge.
        /// </summary>
        [JsonPropertyName("bridge")]
        public bool Bridge { get; set; }

        /// <summary>
        /// List of lights to be updated or empty if no update available.
        /// </summary>
        [JsonPropertyName("lights")]
        public string[] Lights { get; set; }

        /// <summary>
        /// List of sensors to be updated or empty if no update available
        /// </summary>
        [JsonPropertyName("sensors")]
        public string[] Sensors { get; set; }
    }
}