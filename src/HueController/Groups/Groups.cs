using PReardon.HueController.Groups.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace PReardon.HueController.Groups
{
    public class Groups
    {
        private readonly HttpClient _httpClient;
        private readonly string _userName;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public Groups(HttpClient httpClient, string username)
        {
            _httpClient = httpClient;
            _userName = username;

            _jsonSerializerOptions = new JsonSerializerOptions();
            _jsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        }

        /// <summary>
        /// Gets a list of all groups that have been added to the bridge. A group is a list of lights that can be created, modified and deleted by a user.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>Returns a list of all groups in the system, each group has a name and unique identification number.</returns>
        public async Task<Dictionary<string, Group>> GetAllGroupsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await _httpClient.GetAsync($"/api/{_userName}/groups", cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Dictionary<string, Group>>(content, _jsonSerializerOptions);
            }

            return null;
        }

        /// <summary>
        /// Creates a new group containing the lights specified and optional name. A new group is created in the bridge with the next available id.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task CreateGroupAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the group attributes, e.g. name, light membership and last command for a given group.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task GetGroupAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Allows the user to modify the name, light and class membership of a group.
        /// </summary>
        /// <param name="id">Id of the group to Update</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task UpdateGroupAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Modifies the state of all lights in a group.
        /// User created groups will have an ID of 1 or higher; however a special group with an ID of 0 also exists containing all the lamps known by the bridge.
        /// </summary>
        /// <param name="id">Id of the group to Update</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Success</returns>
        public async Task<bool> SetGroupStateAsync(string id, SetGroupStateRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/api/{_userName}/groups/{id}/action", requestContent, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
        /// <summary>
        /// Deletes the specified group from the bridge.
        /// </summary>
        /// <param name="id">Id of the group to Update</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task DeleteGroupAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

    }
}
