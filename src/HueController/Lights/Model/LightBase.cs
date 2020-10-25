using System.Text.Json.Serialization;

namespace PReardon.HueController.Lights.Model
{
    public class LightBase
    {
        /// <summary>
        /// Details the state of the light
        /// </summary>
        [JsonPropertyName("state")]
        public LightStateBase State { get; set; }
        /// <summary>
        /// A fixed name describing the type of light e.g. “Extended color light”.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
        /// <summary>
        /// A unique, editable name given to the light.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
        /// <summary>
        /// The hardware model of the light.
        /// </summary>
        [JsonPropertyName("modelid")]
        public string ModelId { get; set; }
        /// <summary>
        /// The manufacturer name.
        /// </summary>
        [JsonPropertyName("manufacturername")]
        public string ManufacturerName { get; set; }
        /// <summary>
        /// Unique id of the device. The MAC address of the device with a unique endpoint id in the form: AA:BB:CC:DD:EE:FF:00:11-XX
        /// </summary>
        [JsonPropertyName("uniqueid")]
        public string UniqueId { get; set; }
        /// <summary>
        /// An identifier for the software version running on the light.
        /// </summary>
        [JsonPropertyName("swversion")]
        public string SwVersion { get; set; } // "1.50.2_r30933",
    }
}
