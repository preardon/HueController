using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PReardon.HueController.Groups.Model
{
    public class GenericSuccessResponseItem
    {
        [JsonPropertyName("success")]
        public Dictionary<string,string> Success { get; set; }
    }
}
