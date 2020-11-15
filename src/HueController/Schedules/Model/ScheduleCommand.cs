using PReardon.HueController.Model;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PReardon.HueController.Schedules.Model
{
    public class ScheduleCommand
    {
        /// <summary>
        /// Path to a light resource, a group resource or any other bridge resource (including “/api/<username>/”)
        /// </summary>
        [JsonPropertyName("address")]
        [Required]
        [MinLength(1)]
        [MaxLength(62)]
        public string Address { get; set; }

        /// <summary>
        /// 	JSON string to be sent to the relevant resource.
        /// </summary>
        [JsonPropertyName("body")]
        [MinLength(1)]
        [MaxLength(90)]
        public ScheduleCommandBody Body { get; set; }

        /// <summary>
        /// The HTTPS method used to send the body to the given address. Either “POST”, “PUT”, “DELETE” for local addresses.
        /// </summary>
        [JsonPropertyName("method")]
        [Required]
        public HttpMethod Method { get; set; }
    }
}