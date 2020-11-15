using System.Text.Json.Serialization;

namespace PReardon.HueController.Schedules.Model
{
    public class ScheduleCommandBody
    {
        [JsonPropertyName("scene")]
        public string Scene { get; set; }
        [JsonPropertyName("on")]
        public bool? On { get; set; }
    }
}
