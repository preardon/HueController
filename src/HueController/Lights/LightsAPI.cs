using PReardon.HueController.Lights.Model;
using System;
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
        public static async Task<Dictionary<string, Light>> GetAllLightsAsync(HttpClient client, JsonSerializerOptions jso, string userName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await client.GetAsync($"/api/{userName}/lights", cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Dictionary<string, Light>>(content, jso);
            }

            return null;
        }

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
        public async Task RenameLight(string id, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var uri = $"/api/{_userName}/lights/{id}";
            throw new NotImplementedException();
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
                //var content = await response.Content.ReadAsStringAsync();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Deletes a light from the bridge.
        /// </summary>
        /// <param name="id">Id of Light to be set</param>
        /// <returns></returns>
        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var uri = $"/api/{_userName}/lights/{id}";
            throw new NotImplementedException();
        }

        public async Task GetNewLightsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public async Task SearchForNewLightsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}
