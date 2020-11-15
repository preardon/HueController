using PReardon.HueController.Model;
using PReardon.HueController.Lights.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace PReardon.HueController.Lights
{
    public class LightsAPI
    {
        private readonly HttpClient _httpClient;
        private readonly string _userName;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public LightsAPI(HttpClient httpClient, string username, JsonSerializerOptions jso)
        {
            _httpClient = httpClient;
            _userName = username;

            _jsonSerializerOptions = jso;
        }

        /// <summary>
        /// Gets a list of all lights that have been discovered by the bridge.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>List of all lights</returns>
        public async Task<Dictionary<string, Light>> GetAllLightsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await _httpClient.GetAsync($"/api/{_userName}/lights", cancellationToken);

            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Dictionary<string, Light>>(content, _jsonSerializerOptions);
            }

            return null;
        }

        /// <summary>
        /// Gets the attributes and state of a given light.
        /// </summary>
        /// <param name="id">Id of Light</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Attribute and State of Light</returns>
        public async Task<GetLightResponse> GetLightAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await _httpClient.GetAsync($"/api/{_userName}/lights/{id}", cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<GetLightResponse>(content, _jsonSerializerOptions);
            }

            return null;
        }

        /// <summary>
        /// Used to rename lights. A light can have its name changed when in any state, including when it is unreachable or off.
        /// </summary>
        /// <param name="id">Id of Light to be Renamed</param>
        /// <param name="name">New name of light</param>
        /// <returns></returns>
        public async Task<List<GenericSuccessResponseItem>> RenameLight(string id, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new LightRenameRequest(name);
            var requestContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/api/{_userName}/lights/{id}", requestContent, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<GenericSuccessResponseItem>>(content, _jsonSerializerOptions);
            }

            return null;
        }

        /// <summary>
        /// Allows the user to turn the light on and off, modify the hue and effects.
        /// </summary>
        /// <param name="id">Id of Light to be set</param>
        /// <param name="request">Request for the light</param>
        /// <returns></returns>
        public async Task<bool> SetStateAsync(string id, SetLightStateRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/api/{_userName}/lights/{id}/state", requestContent, cancellationToken);

            if(response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Deletes a light from the bridge.
        /// </summary>
        /// <param name="id">Id of Light to be Deleted</param>
        /// <returns>Success</returns>
        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await _httpClient.DeleteAsync($"/api/{_userName}/lights/{id}", cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets a list of lights that were discovered the last time a search for new lights was performed. The list of new lights is always deleted when a new search is started.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Dictionary<string, object>> GetNewLightsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await _httpClient.GetAsync($"/api/{_userName}/lights/new", cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Dictionary<string, object>>(content, _jsonSerializerOptions);
            }

            return null;
        }

        /// <summary>
        /// Starts searching for new lights.
        /// The bridge will open the network for 40s.The overall search might take longer since the configuration of(multiple) new devices can take longer.If many devices are found the command will have to be issued a second time after discovery time has elapsed.If the command is received again during search the search will continue for at least an additional 40s.
        /// When the search has finished, new lights will be available using the get new lights command.In addition, the new lights will now be available by calling get all lights or by calling get group attributes on group 0. Group 0 is a special group that cannot be deleted and will always contain all lights known by the bridge.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> SearchForNewLightsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await _httpClient.PostAsync($"/api/{_userName}/lights", null, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return true;
            }

            return false;
        }
    }
}
