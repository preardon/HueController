namespace PReardon.HueController.Scenes.Model
{
    public enum SceneType
    {
        /// <summary>
        /// Default
        /// </summary>
        LightScene,
        /// <summary>
        /// Represents a scene which links to a specific group. While creating a new GroupScene, the group attribute shall be provided.
        /// The lights array is a read-only attribute, it cannot be modified, and shall not be provided upon GroupScene creation.
        /// When lights in a group is changed, the GroupScenes associated to this group will be automatically updated with the new list of lights in the group.The new lights added to the group will be assigned with default states for associated GroupScenes.
        /// When a group is deleted or becomes empty, all the GroupScenes associated to the group will be deleted automatically.
        /// </summary>
        GroupScene
    }
}