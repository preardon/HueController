using PReardon.HueController.Discovery;
using PReardon.HueController.Groups;
using PReardon.HueController.Groups.Model;
using PReardon.HueController.Lights;
using PReardon.HueController.Lights.Model;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HueController
{
    class Program
    {
        private static string _userName = "";
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            var bridgeinfo = await (new NuPnPDisco()).Discover();

            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri($"http://{bridgeinfo[0].Internalipaddress}");
            var lightsClient = new Lights(httpClient, _userName);
            var lights = await lightsClient.GetAllLightsAsync();

            var onLights = lights.Where(l => l.Value.State.On).Select(l => l.Key).ToList();

            //foreach(var light in onLights)
            //{
            //    await lightsClient.SetStateAsync(light, new SetLightStateRequest { On = false });
            //}

            var groupsClient = new Groups(httpClient, _userName);
            Console.WriteLine("Looking for Groups");
            var groups = await groupsClient.GetAllGroupsAsync();

            foreach (var group in groups)
            {
                Console.WriteLine($"Found Group: {group.Value.Name}");
            }

            var studyId = groups.Where(g => g.Value.Name == "Study").Select(g => g.Key).First();

            await groupsClient.SetGroupStateAsync(studyId, new SetGroupStateRequest
            {
                On = false,
                TransitionTime = 10
            });
        }
    }
}
