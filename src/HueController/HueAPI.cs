using PReardon.HueController.Configuration;
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
    public class HueAPI
    {
        private readonly HttpClient _httpClient;
        private string _userName;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public GroupsAPI Groups { get; private set; }
        public LightsAPI Lights { get; private set; }
        public ConfigurationAPI Configuration { get; private set; }

        public HueAPI()
        {
            _httpClient = new HttpClient();

            _jsonSerializerOptions = new JsonSerializerOptions();
            _jsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            _jsonSerializerOptions.IgnoreNullValues = true;

            Disco().Wait();

            if (!String.IsNullOrWhiteSpace(_userName)) setAPIs();
        }
        public HueAPI(string userName) : this()
        {
            _userName = userName;
        }
        
        public void SetUserName(string userName)
        {
            _userName = userName;
            setAPIs();
        }

        private void setAPIs()
        {
            Lights = new LightsAPI(_httpClient, _userName, _jsonSerializerOptions);
            Groups = new GroupsAPI(_httpClient, _userName, _jsonSerializerOptions);
            Configuration = new ConfigurationAPI(_httpClient, _userName, _jsonSerializerOptions);
        }

        public async Task Disco()
        {
            var bridgeinfo = await (new NuPnPDisco()).Discover();
            _httpClient.BaseAddress = new Uri($"http://{bridgeinfo[0].Internalipaddress}");
        }
    }
}
