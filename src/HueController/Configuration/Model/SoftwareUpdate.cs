using System;
using System.Text.Json.Serialization;

namespace PReardon.HueController.Configuration.Model
{
    [Obsolete("This only works with firmware before 1.20 please use SoftwareUpdate2")]
    public class SoftwareUpdate
    {
        /// <summary>
        /// Setting this flag to true lets the bridge search for software updates in the portal. After the search attempt, this flag is set back to false. Requires portal connection to update server.
        /// </summary>
        [JsonPropertyName("checkforupdate")]
        public bool CheckForUpdate { get; set; }

        /// <summary>
        /// Details the type of updates available.
        /// </summary>
        [JsonPropertyName("devicetypes")]
        public DeviceTypes DeviceTypes { get; set; }

        /// <summary>
        /// can only be updated manually from state 2 into state 3. All other transitions are invalid and will return an error 3. Updating this constitutes acceptance by the app of the software update.
        /// </summary>
        [JsonPropertyName("updatestate")]
        public UpdateState UpdateState { get; set; }

        /// <summary>
        /// Can only be updated when its state is true and it is being set to false. All other transitions are invalid and will return an error 3.  is set to true when software has been installed successfully. The app should inform the user that the updates are installed and shall reset this flag to false to avoid multiple user notifications.
        /// </summary>
        [JsonPropertyName("notify")]
        public bool Notify { get; set; }

        /// <summary>
        /// URL to release notes.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>
        /// Brief release notes
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
}