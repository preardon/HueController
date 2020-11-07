using PReardon.HueController.Lights.Model;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PReardon.HueController.Groups.Model
{
    public class GroupActionBase
    {
        /// <summary>
        /// On/Off state of the Group. On=true, Off=false
        /// </summary>
        [JsonPropertyName("on")]
        public bool? On { get; set; }
        /// <summary>
        /// Brightness of the Group. This is a scale from the minimum brightness the Group is capable of, 1, to the maximum capable brightness, 254.
        /// </summary>
        [JsonPropertyName("bri")]
        [Range(1, 254)]
        public int? Brightness { get; set; }
        /// <summary>
        /// Hue of the Group. This is a wrapping value between 0 and 65535. Note, that hue/sat values are hardware dependent which means that programming two devices with the same value does not garantuee that they will be the same color. Programming 0 and 65535 would mean that the Group will resemble the color red, 21845 for green and 43690 for blue.
        /// </summary>
        [JsonPropertyName("hue")]
        [Range(0, 65535)]
        public int? Hue { get; set; }
        /// <summary>
        /// Saturation of the Group. 254 is the most saturated (colored) and 0 is the least saturated (white).
        /// </summary>
        [JsonPropertyName("sat")]
        [Range(0, 254)]
        public int? Saturation { get; set; }
        /// <summary>
        /// The dynamic effect of the Group, can either be “none” or “colorloop”.If set to colorloop, the light will cycle through all hues using the current brightness and saturation settings.
        /// </summary>
        [JsonPropertyName("effect")]
        public LightStateEffect? Effect { get; set; }
        /// <summary>
        /// The x and y coordinates of a color in CIE color space.
        /// The first entry is the x coordinate and the second entry is the y coordinate.Both x and y are between 0 and 1. Using CIE xy, the colors can be the same on all lamps if the coordinates are within every lamps gamuts(example: “xy”:[0.409,0.5179] is the same color on all lamps). If not, the lamp will calculate it’s closest color and use that.The CIE xy color is absolute, independent from the hardware.
        /// </summary>
        [JsonPropertyName("xy")]
        public double[] XY { get; set; } // [0.2055, 0.3748],
        /// <summary>
        /// The Mired Color temperature of the Group. 2012 connected lights are capable of 153 (6500K) to 500 (2000K).
        /// </summary>
        [JsonPropertyName("ct")]
        public int? ColourTemperature { get; set; }

        [JsonPropertyName("alert")]
        public string Alert { get; set; }
        
    }
}
