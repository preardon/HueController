using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PReardon.HueController.Configuration.Model
{
    public class BridgeConfiguration : BridgeConfigurationBase
    {
        /// <summary>
        /// Contains information related to software updates.
        /// </summary>
        [JsonPropertyName("swupdate2")]
        public SoftwareUpdate2 SwUpdate2 { get; set; }

        /// <summary>
        /// A list of whitelisted user IDs.
        /// </summary>
        [JsonPropertyName("whitelist")]
        public Dictionary<string, WhiteListItem> Whitelist { get; set; }

        /// <summary>
        /// Object representing the portal state.
        /// </summary>
        [JsonPropertyName("portalstate")]
        public PortalState PortalState { get; set; }

        /// <summary>
        /// The version of the hue API in the format <major>.<minor>.<patch>, for example 1.2.1
        /// </summary>
        [JsonPropertyName("apiversion")]
        public string ApiVersion { get; set; }

        /// <summary>
        /// Software version of the bridge.
        /// </summary>
        [JsonPropertyName("swversion")]
        public string SwVersion { get; set; }

        /// <summary>
        /// MAC address of the bridge.
        /// </summary>
        [JsonPropertyName("mac")]
        public string MAC { get; set; }

        /// <summary>
        /// This indicates whether the bridge is registered to synchronize data with a portal account. When setting portalservices to true it shall come with a terms and conditions (www.meethue.com/terms) and privacy notice (www.meethue.com/privacy). A user shall accept it before setting portal services to true.
        /// </summary>
        [JsonPropertyName("portalservices")]
        public bool PortalServices { get; set; }

        /// <summary>
        /// The local time of the bridge. “none” if not available.
        /// </summary>
        [JsonPropertyName("localtime")]
        public string LocalTime { get; set; }

        /// <summary>
        /// This parameter uniquely identifies the hardware model of the bridge (BSB001, BSB002).
        /// </summary>
        [JsonPropertyName("modelid")]
        [MinLength(6)]
        [MaxLength(32)]
        public string ModelId { get; set; }

        /// <summary>
        /// The unique bridge id. This is currently generated from the bridge Ethernet mac address.
        /// </summary>
        [JsonPropertyName("bridgeid")]
        public string BridgeId { get; set; }

        /// <summary>
        /// Indicates if bridge settings are factory new.
        /// </summary>
        [JsonPropertyName("factorynew")]
        public bool FactoryNew { get; set; }

        /// <summary>
        /// If a bridge backup file has been restored on this bridge from a bridge with a different bridgeid, it will indicate that bridge id, otherwise it will be null.
        /// </summary>
        [JsonPropertyName("replacesbridgeid")]
        public string ReplacesBridgeId { get; set; }

        /// <summary>
        /// The version of the datastore.
        /// </summary>
        [JsonPropertyName("datastoreversion")]
        public string DatastoreVersion { get; set; }

        /// <summary>
        /// Name of the starterkit created in the factory.
        /// </summary>
        [JsonPropertyName("starterkitid")]
        public string StarterKitId { get; set; }
    }
}
