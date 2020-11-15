using System.Text.Json.Serialization;

namespace PReardon.HueController.Schedules.Model
{
    public class CreateScheduleRequest : ScheduleBase
    {
        /// <summary>
        /// When true: Resource is automatically deleted when not referenced anymore in any resource link. Only on creation of resource. “false” when omitted.
        /// </summary>
        [JsonPropertyName("recycle")]
        public bool? Recycle { get; set; }
    }
}
