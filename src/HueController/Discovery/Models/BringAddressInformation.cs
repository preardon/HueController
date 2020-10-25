using System.Text.Json.Serialization;

namespace PReardon.HueController.Discovery.Models
{
    public class BringAddressInformation
    {
        //[{"id":"001788fffe63eda0","internalipaddress":"192.168.0.12"}]
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("internalipaddress")]
        public string Internalipaddress { get; set; }
    }

}
