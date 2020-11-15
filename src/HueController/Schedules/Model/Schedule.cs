using System;
using System.Text.Json.Serialization;

namespace PReardon.HueController.Schedules.Model
{
    public class Schedule : ScheduleBase
    {
        

        [JsonPropertyName("created")]
        public DateTime Created { get; set; }

        [JsonPropertyName("starttime")]
        public string StartTime { get; set; }
    }
}
