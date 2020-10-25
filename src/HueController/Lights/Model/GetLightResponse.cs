using System.Text.Json.Serialization;

namespace PReardon.HueController.Lights.Model
{
    public class GetLightResponse : LightBase
    {
        /// <summary>
        /// 	Unique ID of the luminaire the light is a part of in the format: AA:BB:CC:DD-XX-YY.  AA:BB:, … represents the hex of the luminaireid, XX the lightsource position (incremental but may contain gaps) and YY the lightpoint position (index of light in luminaire group).  A gap in the lightpoint position indicates an incomplete luminaire (light search required to discover missing light points in this case).
        /// </summary>
        [JsonPropertyName("luminaireuniqueid")]
        public string LuminaireUniqueId { get; set; }
        /// <summary>
        /// Current light supports streaming features
        /// </summary>
        [JsonPropertyName("streaming")]
        public bool Streaming { get; set; }
        /// <summary>
        /// Indicates if a lamp can be used for entertainment streaming as renderer
        /// </summary>
        [JsonPropertyName("renderer")]
        public bool Renderer { get; set; }
        /// <summary>
        /// Indicates if a lamp can be used for entertainment streaming as a proxy node
        /// </summary>
        [JsonPropertyName("proxy")]
        public bool Proxy { get; set; }
    }
}
