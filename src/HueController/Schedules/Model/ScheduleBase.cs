using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PReardon.HueController.Schedules.Model
{
    public class ScheduleBase
    {
        /// <summary>
        /// Name for the new schedule. If a name is not specified then the default name, “schedule”, is used.If the name is already taken a space and number will be appended by the bridge, e.g. “schedule 1”.
        /// </summary>
        [MaxLength(32)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Description of the new schedule. If the description is not specified it will be empty.
        /// </summary>
        [MaxLength(64)]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Command to execute when the scheduled event occurs. If the command is not valid then an error of type 7 will be raised.
        /// </summary>
        [Required]
        [JsonPropertyName("command")]
        public ScheduleCommand command { get; set; }

        /// <summary>
        /// Time when the scheduled event will occur. Time is measured in the bridge in UTC time. Either time or localtime has to be provided.
        /// DEPRECATED This attribute will be removed in the future.Please use localtime instead.
        /// The following time patterns are allowed:
        ///   - Absolute time
        ///   - Randomized time
        ///   - Recurring times
        ///   - Recurring randomized times
        ///   -Timers
        /// </summary>
        //[Obsolete("Please use LocalTime instead")]
        //[JsonPropertyName("time")]
        //public string Time { get; set; }

        /// <summary>
        /// Local time when the scheduled event will occur.Either time or localtime has to be provided. A schedule configured with localtime will operate on localtime and is returned along with the time attribute (UTC) for backwards compatibility. The following time patterns are allowed:
        ///   - Absolute time
        ///   - Randomized time
        ///   - Recurring times
        ///   - Recurring randomized times
        ///   - Timers
        /// </summary>
        [JsonPropertyName("localtime")]
        [Required]
        public string LocalTime { get; set; }

        /// <summary>
        /// “enabled”  Schedule is enabled
        /// “disabled”  Schedule is disabled by user.
        /// Application is only allowed to set “enabled” or “disabled”. Disabled causes a timer to reset when activated(i.e.stop & reset). “enabled” when not provided on creation.
        /// </summary>
        [MinLength(5)]
        [MaxLength(16)]
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// If set to true, the schedule will be removed automatically if expired, if set to false it will be disabled. Default is true. Only visible for non-recurring schedules.
        /// </summary>
        [JsonPropertyName("autodelete")]
        public bool AutoDelete { get; set; }
    }
}
