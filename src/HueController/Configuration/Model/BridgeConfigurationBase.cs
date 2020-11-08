using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PReardon.HueController.Configuration.Model
{
    public class BridgeConfigurationBase
    {
        /// <summary>
        /// Name of the bridge. This is also its uPnP name, so will reflect the actual uPnP name after any conflicts have been resolved.
        /// </summary>
        [JsonPropertyName("name")]
        [MinLength(3)]
        [MaxLength(16)]
        public string Name { get; set; }

        /// <summary>
        /// Contains information related to software updates. Deprecated in 1.20
        /// </summary>
        [JsonPropertyName("swupdate")]
        [Obsolete("Please use SwUpdate2")]
        public SoftwareUpdate SwUpdate { get; set; }

        /// <summary>
        /// No longer available as of 1.21. IP Address of the proxy server being used. A value of “none” indicates no proxy.
        /// 
        /// as of 1.37do not allow update anymore.Always returns “none”.
        /// </summary>
        [JsonPropertyName("proxyaddress")]
        [MaxLength(40)]
        public string ProxyAddress { get; set; }

        /// <summary>
        /// No longer available as of 1.21. Port of the proxy being used by the bridge. If set to 0 then a proxy is not being used.
        /// 
        /// as of 1.37do not allow update anymore.Always returns 0.
        /// </summary>
        [JsonPropertyName("proxyport")]
        public int? ProxyPort { get; set; }

        /// <summary>
        /// Indicates whether the link button has been pressed within the last 30 seconds. Starting  1.31, Writing is only allowed for Portal access via cloud application_key.
        /// </summary>
        [JsonPropertyName("linkbutton")]
        public bool? LinkButton { get; set; }

        /// <summary>
        /// IP address of the bridge.
        /// </summary>
        [JsonPropertyName("ipaddress")]
        public string IPAddress { get; set; }

        /// <summary>
        /// Network mask of the bridge.
        /// </summary>
        [JsonPropertyName("netmask")]
        public string NetMask { get; set; }

        /// <summary>
        /// Gateway IP address of the bridge.
        /// </summary>
        [JsonPropertyName("gateway")]
        public string Gateway { get; set; }

        /// <summary>
        /// Whether the IP address of the bridge is obtained with DHCP.	
        /// </summary>
        [JsonPropertyName("dhcp")]
        public bool DHCP { get; set; }

        /// <summary>
        /// Current time stored on the bridge.
        /// </summary>
        [JsonPropertyName("UTC")]
        public string UTC { get; set; }

        /// <summary>
        /// Timezone of the bridge as OlsenIDs, like “Europe/Amsterdam” or “none” when not configured.
        /// </summary>
        [JsonPropertyName("timezone")]
        [MaxLength(32)]
        public string Timezone { get; set; }

        /// <summary>
        /// The current wireless frequency channel used by the bridge. It can take values of 11, 15, 20,25 or 0 if undefined (factory new).
        /// </summary>
        [JsonPropertyName("zigbeechannel")]
        public int? ZigbeeChannel { get; set; }
    }
}
