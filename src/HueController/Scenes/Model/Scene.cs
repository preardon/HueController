using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PReardon.HueController.Scenes.Model
{
    public class Scene
    {
        /// <summary>
        /// Human readable name of the scene. Is set to <id> if omitted on creation.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Type of the scene.
        /// If not provided on creation a “LightScene” is created.Supported types:
        ///   - LightScene
        ///   - GroupScene
        /// </summary>
        [JsonPropertyName("type")]
        public SceneType Type { get; set; }

        /// <summary>
        /// The light ids which are in the scene. This array can empty. As of 1.11 it must contain at least 1 element. If an invalid lights resource is given, error 7 is returned and the scene is not created.  When writing, lightstate of all lights in list will be overwritten with current light state. As of 1.15 when writing, lightstate of lights which are not yet in list will be created with current light state.
        /// The array is informational for GroupScene, it is generated automatically from the lights in the linked group.
        /// </summary>
        [JsonPropertyName("lights")]
        public List<string> Lights { get; set; }

        /// <summary>
        /// group ID that a scene is linked to.
        /// </summary>
        [JsonPropertyName("group")]
        public string Group { get; set; }

        /// <summary>
        /// Whitelist user that created or modified the content of the scene. Note that changing name does not change the owner.
        /// </summary>
        [JsonPropertyName("owner")]
        public string Owner { get; set; }

        /// <summary>
        /// Indicates whether the scene can be automatically deleted by the bridge. Only available by POSTSet to ‘false’ when omitted. Legacy scenes created by PUT are defaulted to true. When set to ‘false’ the bridge keeps the scene until deleted by an application.
        /// </summary>
        [JsonPropertyName("recycle")]
        public bool? Recycle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("locked")]
        public bool? Locked { get; set; }

        /// <summary>
        /// Indicates that the scene is locked by a rule or a schedule and cannot be deleted until all resources requiring or that reference the scene are deleted.
        /// </summary>
        [JsonPropertyName("appdata")]
        public AppData AppData { get; set; }

        /// <summary>
        /// Only available on a GET of an individual scene resource (/api/<username>/scenes/<id>). Not available for scenes created via a PUT. Reserved for future use.
        /// </summary>
        [JsonPropertyName("picture")]
        public string Picture { get; set; }

        /// <summary>
        /// Unique ID for an image representing the scene. Only available for scenes create from Signify images by Hue application.
        /// </summary>
        [JsonPropertyName("image")]
        public string Image { get; set; }

        /// <summary>
        /// UTC time the scene has been created or has been updated by a PUT. Will be null when unknown (legacy scenes).
        /// </summary>
        [JsonPropertyName("lastupdated")]
        public DateTime LastUpdated { get; set; }

        /// <summary>
        /// Version of scene document:
        /// 1 – Scene created via PUT, lightstates will be empty.
        /// 2 – Scene created via POST lightstates available.
        /// </summary>
        [JsonPropertyName("version")]
        public int Version { get; set; }
    }
}
