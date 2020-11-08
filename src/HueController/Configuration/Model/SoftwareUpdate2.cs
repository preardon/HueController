using System;
using System.Text.Json.Serialization;

namespace PReardon.HueController.Configuration.Model
{
    public class SoftwareUpdate2
    {
        //ToDo: Add Bridge Item

        /// <summary>
        /// Setting this flag true lets the bridge search for software update at the portal. After the search attempt, this flag is reset to false. Requires portal connection to update software.
        /// 
        /// If software update server cannot be reached /config/ internetservices/swupdate will be “disconnected”.
        /// </summary>
        [JsonPropertyName("checkforupdate")]
        public bool CheckForUpdate { get; set; }

        /// <summary>
        /// State of software update for the system
        /// </summary>
        [JsonPropertyName("state")]
        public SoftwareUpdateState State { get; set; }

        /// <summary>
        /// Writing “true” triggers installation of software updates when in state anyreadytoinstall or allreadytoinstall.
        /// </summary>
        [JsonPropertyName("install")]
        public bool Install { get; set; }

        /// <summary>
        /// Automatic update configuration object.
        /// </summary>
        [JsonPropertyName("autoinstall")]
        public AutoInstall AutoInstall { get; set; }

        /// <summary>
        /// Timestamp of last change in system configuration
        /// 	last software configuration update requires additional software to be transferred(noupdates -> transferring)
        /// 	last successful transfer of a software image to a device
        /// last successful installation of a software image on a device
        /// </summary>
        [JsonPropertyName("lastchange")]
        public DateTime LastChange { get; set; }

        /// <summary>
        /// Time of last software update.
        /// </summary>
        [JsonPropertyName("lastinstall")]
        public DateTime LastInstall { get; set; }
    }
}