using System.Text.Json.Serialization;

namespace PReardon.HueController.Configuration.Model
{
    public class PortalState
    {
        //ToDo: Confirm this, the Doco is a bit off

        [JsonPropertyName("signedon")]
        public bool SignedOn { get; set; }

        [JsonPropertyName("incoming")]
        public bool Incoming { get; set; }

        [JsonPropertyName("outgoing")]
        public bool Outgoing { get; set; }

        [JsonPropertyName("communication")]
        public string Communication { get; set; }
    }
}