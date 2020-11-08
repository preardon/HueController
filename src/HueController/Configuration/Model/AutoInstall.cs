using System;
using System.Text.Json.Serialization;

namespace PReardon.HueController.Configuration.Model
{
    public class AutoInstall
    {
        /// <summary>
        /// Indicates if automatic update is activated. Default is false
        /// </summary>
        [JsonPropertyName("on")]
        public bool On { get; set; }

        /// <summary>
        /// T[hh]:[mm]:[ss] Local time of day.
        /// The bridge auto.updates for bridge and zigbee devices.The installation time will be randomized between updatetime and updatetime+T01:00:00. Default is T14:00:00.
        /// </summary>
        [JsonPropertyName("updatetime")]
        public string UpdateTime { get; set; }
    }
}