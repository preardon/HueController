using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PReardon.HueController.Scenes.Model
{
    public class AppData
    {
        /// <summary>
        /// App specific version of the data field. App should take versioning into account when parsing the data string.
        /// </summary>
        [JsonPropertyName("version")]
        public int Version { get; set; }

        /// <summary>
        /// App specific data. Free format string.
        /// </summary>
        [JsonPropertyName("data")]
        [MinLength(1)]
        [MaxLength(16)]
        public string Data { get; set; }
    }
}
