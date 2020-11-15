using PReardon.HueController.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace PReardon.HueController
{
    public abstract class ApiBase
    {
        protected HttpClient _httpClient;
        protected JsonSerializerOptions _jsonSerializerOptions;
        protected string _pathBase;

        /// <summary>
        /// Http Get Request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="additionalPath">The Aditional Parameters for the Request</param>
        /// <param name="cancellationToken"></param>
        /// <returns>T</returns>
        protected async Task<T> getAsync<T>(string additionalPath = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var path = string.Join("/", _pathBase, additionalPath);
            var response = await _httpClient.GetAsync(path, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(content, _jsonSerializerOptions);
            }

            return default(T);
        }

        protected async Task<T> postAsync<T>(object request, string additionalPath = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var json = JsonSerializer.Serialize(request, _jsonSerializerOptions);
            var path = string.Join("/", _pathBase, additionalPath);
            var requestContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(path, requestContent, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(content, _jsonSerializerOptions);
            }

            return default(T);
        }

        protected async Task<T> putAsync<T>(object request, string additionalPath = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var json = JsonSerializer.Serialize(request, _jsonSerializerOptions);
            var path = string.Join("/", _pathBase, additionalPath);
            var requestContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(path, requestContent, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(content, _jsonSerializerOptions);
            }

            return default(T);
        }


        protected async Task<Dictionary<string, GenericSuccessResponseItem>> deleteAsync(string additionalPath, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await deleteAsync<Dictionary<string, GenericSuccessResponseItem>>(path, cancellationToken);
        }

        protected async Task<T> deleteAsync<T>(string path, CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await _httpClient.DeleteAsync($"{_pathBase}/{path}", cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(content, _jsonSerializerOptions);
            }

            return default(T);
        }

    }
}
