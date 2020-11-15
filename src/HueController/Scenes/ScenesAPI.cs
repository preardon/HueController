using PReardon.HueController.Model;
using PReardon.HueController.Scenes.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace PReardon.HueController.Scenes
{
    public class ScenesAPI : ApiBase
    {
        public ScenesAPI(HttpClient httpClient, string username, JsonSerializerOptions jso)
        {
            _httpClient = httpClient;

            _jsonSerializerOptions = jso;
            _pathBase = $"/api/{username}/scenes";
        }

        /// <summary>
        /// Gets a list of all scenes currently stored in the bridge. Scenes are represented by a scene id, a name and a list of lights which are part of the scene. The name resource can contain a “friendly name” or can contain a unique code.  Scenes are stored in the bridge.  This means that scene light state settings can easily be retrieved by developers (using ADD link) and shown in their respective UI’s. Cached scenes (scenes stored with PUT) will be deprecated in the future.
        /// Additionally, bridge scenes should not be confused with the preset scenes stored in the Android and iOS Hue apps.In the apps these scenes are stored internally.Once activated they may then appear as a bridge scene.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>List of all scenes in the bridge.</returns>
        public async Task<Dictionary<string, Scene>> GetAllScenesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await getAsync<Dictionary<string, Scene>>(cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Gets the attributes of a given scene. As mentioned above, please note that lightstates are displayed when an individual scene is retrieved (but not for all scenes).
        /// </summary>
        /// <param name="id">Id of Scene</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Scene> GetSceneAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await getAsync<Scene>(id, cancellationToken);
        }

        public async Task<Dictionary<string, GenericSuccessResponseItem>> CreateSceneAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public async Task<Dictionary<string, GenericSuccessResponseItem>> UpdateSceneAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a scene from the bridge.
        /// For Version 1 scenes(scenes created with PUT) or Version 2 scenes(scenes created with POST with the recycle flag set to true and locked to false) when the maximum number of scenes has been reached the scene which has been used the least is recycled.
        /// </summary>
        /// <param name="id">Id of the Scene to be deleted</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Dictionary<string, GenericSuccessResponseItem>> DeleteSceneAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await deleteAsync(id, cancellationToken);
        }
    }
}
