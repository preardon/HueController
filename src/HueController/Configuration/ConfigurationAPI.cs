using PReardon.HueController.Configuration.Model;
using PReardon.HueController.Groups.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace PReardon.HueController.Configuration
{
    public class ConfigurationAPI
    {
        private readonly HttpClient _httpClient;
        private readonly string _userName;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public ConfigurationAPI(HttpClient httpClient, string username, JsonSerializerOptions jso)
        {
            _httpClient = httpClient;
            _userName = username;

            _jsonSerializerOptions = jso;
        }

        /// <summary>
        /// Creates a new user. The link button on the bridge must be pressed and this command executed within 30 seconds.
        /// Once a new user has been created, the user key is added to a ‘whitelist’, allowing access to API commands that require a whitelisted user.At present, all other API commands require a whitelisted user.
        /// We ask that published apps use the name of their app as the devicetype
        /// </summary>
        /// <param name="request">Create User Request</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Dictionary<string, CreateUserResponseItem>> CreateUserAsync(CreateUserRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"/api", requestContent, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Dictionary<string, CreateUserResponseItem>>(content, _jsonSerializerOptions);
            }

            return null;
        }

        /// <summary>
        /// Returns list of all configuration elements in the bridge. Note all times are stored in UTC.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<BridgeConfiguration> GetConfigurationAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await _httpClient.GetAsync($"/api/{_userName}/config", cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<BridgeConfiguration>(content, _jsonSerializerOptions);
            }

            return null;
        }

        /// <summary>
        /// Allows the user to set some configuration values.
        /// </summary>
        /// <param name="config">Configuration to Update the Bridge with</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> UpdateConfigurationAsync(BridgeConfigurationUpdate config, CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestContent = new StringContent(JsonSerializer.Serialize(config), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/api/{_userName}/config", requestContent, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                //ToDo: fix return
                var content = await response.Content.ReadAsStringAsync();
                return true;
                //return JsonSerializer.Deserialize<Dictionary<string, CreateUserResponseItem>>(content, _jsonSerializerOptions);
            }

            return false;
        }

        /// <summary>
        /// Deletes the specified user, <element>, from the whitelist.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<GenericSuccessResponseItem>> DeleteUserFromWhitelistAsync(string applicationKey, string user, CancellationToken cancellationToken = default(CancellationToken))
        {
            //ToDo: the Docco specifics Application key not UserName Check this
            var response = await _httpClient.GetAsync($"/api/{applicationKey}/config/whitelist/{user}", cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<GenericSuccessResponseItem>>(content, _jsonSerializerOptions);
            }

            return null;
        }

        /// <summary>
        /// This command is used to fetch the entire datastore from the device, including settings and state information for lights, groups, schedules and configuration. It should only be used sparingly as it is resource intensive for the bridge, but is supplied e.g. for synchronization purposes.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<HueState> GetFullStateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await _httpClient.GetAsync($"/api/{_userName}", cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<HueState>(content, _jsonSerializerOptions);
            }

            return null;
        }
    }
}
