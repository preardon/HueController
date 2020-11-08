using System;
using System.Text.Json.Serialization;

namespace PReardon.HueController.Configuration.Model
{
    public class WhiteListItem
    {

        [JsonPropertyName("last use date")]
        public DateTime LastUseDate { get; set; }

        [JsonPropertyName("create date")]
        public DateTime CreatedDate { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}