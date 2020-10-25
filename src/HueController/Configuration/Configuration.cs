﻿using PReardon.HueController.Configuration.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace PReardon.HueController.Configuration
{
    public class Configuration
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public Configuration(HttpClient httpClient, string username)
        {
            _httpClient = httpClient;
            _baseUrl = $"/api/{username}/config";

            _jsonSerializerOptions = new JsonSerializerOptions();
            _jsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
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
            var response = await _httpClient.PostAsync(_baseUrl, requestContent, cancellationToken);

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
        public async Task GetConfigurationAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Allows the user to set some configuration values.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task UpdateConfigurationAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the specified user, <element>, from the whitelist.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task DeleteUserFromWhitelist(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This command is used to fetch the entire datastore from the device, including settings and state information for lights, groups, schedules and configuration. It should only be used sparingly as it is resource intensive for the bridge, but is supplied e.g. for synchronization purposes.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task GetFullState(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}