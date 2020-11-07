using PReardon.HueController.Discovery;
using PReardon.HueController.Groups;
using PReardon.HueController.Lights;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PReardon.HueController
{
    public class HueController
    {
        private readonly HttpClient _httpClient;
        private readonly string _userName;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public GroupsAPI Groups { get; private set; }
        public LightsAPI Lights { get; private set; }

        public HueController(string username)
        {
            _httpClient = new HttpClient();
            _userName = username;

            _jsonSerializerOptions = new JsonSerializerOptions();
            _jsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            _jsonSerializerOptions.IgnoreNullValues = true;

            Disco().Wait();

            Lights = new LightsAPI(_httpClient, username, _jsonSerializerOptions);
            Groups = new GroupsAPI(_httpClient, username, _jsonSerializerOptions);
        }
        
        public async Task Disco()
        {
            var bridgeinfo = await (new NuPnPDisco()).Discover();
            _httpClient.BaseAddress = new Uri($"http://{bridgeinfo[0].Internalipaddress}");
        }
    }
}
