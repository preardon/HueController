using PReardon.HueController.Model;
using PReardon.HueController.Schedules.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace PReardon.HueController.Schedules
{
    public class SchedulesAPI
    {
        private readonly HttpClient _httpClient;
        private readonly string _userName;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public SchedulesAPI(HttpClient httpClient, string username, JsonSerializerOptions jso)
        {
            _httpClient = httpClient;
            _userName = username;
            _jsonSerializerOptions = jso;
        }

        /// <summary>
        /// Gets a list of all schedules that have been added to the bridge.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>List of all schedules in the system.</returns>
        public async Task<Dictionary<string, Schedule>> GetAllSchedulesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await _httpClient.GetAsync($"/api/{_userName}/schedules", cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Dictionary<string, Schedule>>(content, _jsonSerializerOptions);
            }

            return null;
        }

        /// <summary>
        /// Gets all attributes for a schedule.
        /// </summary>
        /// <param name="scheduleId">Id of Schedule</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Schedule> GetScheduleAsync(string scheduleId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await _httpClient.GetAsync($"/api/{_userName}/schedules/{scheduleId}", cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Schedule>(content, _jsonSerializerOptions);
            }

            return null;
        }

        /// <summary>
        /// Allows the user to create new schedules. The bridge can store up to 100 schedules.
        /// 
        /// Starting 1.17, creations of schedules with PUT is deprecated.PUT on existing schedules is still allowed.
        /// </summary>
        /// <param name="request">Create Schedule request</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Contains a list with a single item that details whether the schedule was added successfully.</returns>
        public async Task<List<GenericSuccessResponseItem>> CreateScheduleAsync(CreateScheduleRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            var json = JsonSerializer.Serialize(request, _jsonSerializerOptions);
            var requestContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"/api/{_userName}/schedules", requestContent, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<GenericSuccessResponseItem>>(content, _jsonSerializerOptions);
            }

            return null;
        }

        /// <summary>
        /// Allows the user to change attributes of a schedule.
        /// </summary>
        /// <param name="scheduleId">Id of the Schedule to be updated</param>
        /// <param name="request">Update Request</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A response to a successful PUT request contains confirmation of the arguments passed in. Note: If the new value is too large to return in the response due to internal memory constraints then a value of “Updated.” is returned.</returns>
        public async Task<List<GenericSuccessResponseItem>> UpdateScheduleAsync(string scheduleId, ScheduleBase request, CancellationToken cancellationToken = default(CancellationToken))
        {
            var json = JsonSerializer.Serialize(request, _jsonSerializerOptions);
            var requestContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/api/{_userName}/schedules/{scheduleId}", requestContent, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<GenericSuccessResponseItem>>(content, _jsonSerializerOptions);
            }

            return null;
        }

        /// <summary>
        /// Deletes a schedule from the bridge.
        /// </summary>
        /// <param name="scheduleId">Id of the Schedule to be Deleted</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<GenericSuccessResponseItem>> DeleteScheduleAsync(string scheduleId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await _httpClient.DeleteAsync($"/api/{_userName}/schedules/{scheduleId}", cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<GenericSuccessResponseItem>>(content, _jsonSerializerOptions);
            }

            return null;
        }
    }
}
