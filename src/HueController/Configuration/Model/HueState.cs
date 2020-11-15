using PReardon.HueController.Groups.Model;
using PReardon.HueController.Lights.Model;
using PReardon.HueController.Schedules.Model;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PReardon.HueController.Configuration.Model
{
    public class HueState
    {
        /// <summary>
        /// A collection of all lights and their attributes.
        /// </summary>
        [JsonPropertyName("lights")]
        public Dictionary<string,Light> Lights { get; set; }
        /// <summary>
        /// A collection of all groups and their attributes.
        /// </summary>
        [JsonPropertyName("groups")]
        public Dictionary<string,Group> Groups { get; set; }
        /// <summary>
        /// All configuration settings.
        /// </summary>
        [JsonPropertyName("config")]
        public BridgeConfiguration Config { get; set; }
        /// <summary>
        /// A collection of all schedules and their attributes.
        /// </summary>
        [JsonPropertyName("schedules")]
        public Dictionary<string, Schedule> Schedules { get; set; }

        //Todo: Fill these in

        /// <summary>
        /// A collection of all scenes and their attributes.
        /// </summary>
        [JsonPropertyName("scenes")]
        public object Scenes { get; set; }
        /// <summary>
        /// A collection of all sensors and their attributes.
        /// </summary>
        [JsonPropertyName("sensors")]
        public object Sensors { get; set; }
        /// <summary>
        /// A collection of all rules and their attributes.
        /// </summary>
        [JsonPropertyName("rules")]
        public object Rules { get; set; }
    }
}
