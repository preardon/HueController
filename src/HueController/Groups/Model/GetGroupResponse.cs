using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PReardon.HueController.Groups.Model
{
    public class GetGroupResponse : Group
    {

        /// <summary>
        /// Uniquely identifies the hardware model of the luminaire. Only present for automatically created Luminaires.
        /// </summary>
        [JsonPropertyName("modelid")]
        public string ModelId { get; set; }

        /// <summary>
        /// Unique Id in AA:BB:CC:DD format for Luminaire groups or AA:BB:CC:DD-XX format for Lightsource groups, where XX is the lightsource position.
        /// </summary>
        [JsonPropertyName("uniqueid")]
        public string UniqueId { get; set; }

        /// <summary>
        /// Category of Room types. Default is: Other.
        /// </summary>
        [JsonPropertyName("class")]
        [Range(1,32)]
        public string Class { get; set; }
    }
}
