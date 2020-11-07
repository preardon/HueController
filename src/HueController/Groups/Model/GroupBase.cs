using System.Text.Json.Serialization;

namespace PReardon.HueController.Groups.Model
{
    public class GroupBase
    {
        /// <summary>
        /// The name of The Group
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Lights in the Group
        /// </summary>
        [JsonPropertyName("lights")]
        public string[] Lights { get; set; }

    }
}
