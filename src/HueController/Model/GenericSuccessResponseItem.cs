using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PReardon.HueController.Model
{
    public class GenericSuccessResponseItem
    {
        [JsonPropertyName("success")]
        public Dictionary<string,object> Success { get; set; }

        [JsonPropertyName("error")]
        public ErrorResponseItem Error { get; set; }
    }
}
