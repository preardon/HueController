using System.Text.Json.Serialization;

namespace PReardon.HueController.Configuration.Model
{
    public class CreateUserResponseItem
    {
        [JsonPropertyName("username")]
        public string UserName { get; set; }
    }
}
