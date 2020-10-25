using System.Text.Json.Serialization;

namespace PReardon.HueController.Lights.Model
{
    public class LightState : LightStateBase
    {
        /// <summary>
        /// Indicates the color mode in which the light is working, this is the last command type it received. Values are “hs” for Hue and Saturation, “xy” for XY and “ct” for Color Temperature. This parameter is only present when the light supports at least one of the values.
        /// </summary>
        [JsonPropertyName("colormode")]
        public string ColorMode { get; set; } //"xy",
        [JsonPropertyName("mode")]
        public string Mode { get; set; } // "homeautomation",
        /// <summary>
        ///  Indicates if a light can be reached by the bridge.
        /// </summary>
        [JsonPropertyName("reachable")]
        public bool Reachable { get; set; }
    }
}
