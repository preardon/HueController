using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PReardon.HueController.Lights.Model
{
    public class LightRenameRequest
    {
        [JsonPropertyName("name")]
        [StringLength(32)]
        public string Name { get; set; }

        public LightRenameRequest() { }
        public LightRenameRequest(string name) : this()
        {
            Name = name;
        }
    }
}
