using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PReardon.HueController.Groups.Model
{
    public class SetGroupStateRequest : GroupActionBase
    {
        /// <summary>
        /// The duration of the transition from the light’s current state to the new state. This is given as a multiple of 100ms and defaults to 4 (400ms). For example, setting transitiontime:10 will make the transition last 1 second.
        /// </summary>
        [JsonPropertyName("transitiontime")]
        public int TransitionTime { get; set; }
        /// <summary>
        /// Increments or decrements the value of the brightness.  bri_inc is ignored if the bri attribute is provided. Any ongoing bri transition is stopped. Setting a value of 0 also stops any ongoing transition. The bridge will return the bri value after the increment is performed.
        /// </summary>
        [JsonPropertyName("bri_inc")]
        [Range(-254, 254)]
        public int IncrimentBrightness { get; set; }
        /// <summary>
        /// Increments or decrements the value of the sat.  sat_inc is ignored if the sat attribute is provided. Any ongoing sat transition is stopped. Setting a value of 0 also stops any ongoing transition. The bridge will return the sat value after the increment is performed.
        /// </summary>
        [JsonPropertyName("sat_inc")]
        [Range(-254, 254)]
        public int InsreaseSaturation { get; set; }
        /// <summary>
        /// Increments or decrements the value of the hue.   hue_inc is ignored if the hue attribute is provided. Any ongoing color transition is stopped. Setting a value of 0 also stops any ongoing transition. The bridge will return the hue value after the increment is performed.Note if the resulting values are < 0 or > 65535 the result is wrapped
        /// </summary>
        [JsonPropertyName("hue_inc")]
        [Range(-65534, 65534)]
        public int IncreaseHue { get; set; }
        /// <summary>
        /// Increments or decrements the value of the ct. ct_inc is ignored if the ct attribute is provided. Any ongoing color transition is stopped. Setting a value of 0 also stops any ongoing transition. The bridge will return the ct value after the increment is performed.
        /// </summary>
        [JsonPropertyName("ct_inc")]
        [Range(-65534, 65534)]
        public int IncreaseColourTemperature { get; set; }
        /// <summary>
        /// Increments or decrements the value of the xy.  xy_inc is ignored if the xy attribute is provided. Any ongoing color transition is stopped. Setting a value of 0 also stops any ongoing transition. Will stop at it’s gamut boundaries. The bridge will return the xy value after the increment is performed. Max value [0.5, 0.5].
        /// </summary>
        [JsonPropertyName("xy_inc")]
        public double[] IncreaseXY { get; set; }
        /// <summary>
        /// The scene identifier if the scene you wish to recall.
        /// </summary>
        [JsonPropertyName("scene")]
        public int Scene { get; set; }
    }
}
