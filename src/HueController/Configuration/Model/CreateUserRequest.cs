using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PReardon.HueController.Configuration.Model
{
    public class CreateUserRequest
    {
        /// <summary>
        /// <application_name>#<devicename>
        /// application_name string 0..20, devicename string 0..19
        ///
        /// (Example: my_hue_app#iphone peter )
        /// </summary>
        [JsonPropertyName("devicetype")]
        [Required]
        public string DeviceType { get; set; }
        /// <summary>
        /// When set to true, a random 16 byte clientkey is generated and returned in the response. This key is encoded as ASCII hex string of length 32.
        /// </summary>
        [JsonPropertyName("generateclientkey")]
        public bool GenerateClientKey { get; set; }
    }
}
