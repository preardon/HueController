using PReardon.HueController;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HueController.ScratchPad
{
    class Program
    {
        private static string _userName = "VT48eEsp1mo7uK3UGUIQd0hP9DCb5EAVq544fu8b";
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            var hue = new HueAPI(_userName);
            //var user = await hue.Configuration.CreateUserAsync(new CreateUserRequest { DeviceType = "my_hue_Application#Computer1" });

            var cfg = await hue.Configuration.GetConfigurationAsync();
            var state = await hue.Configuration.GetFullStateAsync();

            var lights = await hue.Lights.GetAllLightsAsync();

            var onLights = lights.Where(l => l.Value.State.On == true).Select(l => l.Key).ToList();

            //foreach(var light in onLights)
            //{
            //    await lightsClient.SetStateAsync(light, new SetLightStateRequest { On = false });
            //}

            Console.WriteLine("Looking for Groups");
            var groups = await hue.Groups.GetAllGroupsAsync();

            foreach (var group in groups)
            {
                Console.WriteLine($"Found Group: {group.Value.Name}");
            }

            var studyId = groups.Where(g => g.Value.Name == "Study").Select(g => g.Key).First();

            //var builder = new GroupStateBuilder(studyId);
            //await builder.TurnOff()
            //        .WithTransitionTime(10)
            //        .SendAsync(hueController);

            //Thread.Sleep(1500);

            //await builder.TurnOn()
            //    .WithBrightness(254)
            //    .SendAsync(hueController);

        }
    }
}
