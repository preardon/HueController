using System.Text.Json.Serialization;

namespace PReardon.HueController.Configuration.Model
{
    public class BridgeConfigurationUpdate : BridgeConfigurationBase
    {
        /// <summary>
        /// Perform a touchlink action if set to true, setting to false is ignored. When set to true a touchlink procedure starts which adds the closest lamp (within range) to the ZigBee network.  You can then search for new lights and lamp will show up in the bridge.  This field is Write-Only so it is not visible when retrieving the bridge Config JSON
        /// </summary>
        [JsonPropertyName("touchlink")]
        public bool TouchLink { get; set; }
    }
}
