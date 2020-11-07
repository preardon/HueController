using PReardon.HueController.Builders;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HueController.ScratchPad
{
    class Program
    {
        private static string _userName = "";
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            var hueController = new PReardon.HueController.HueController(_userName);
            await hueController.Disco();
            var lights = await hueController.Lights.GetAllLightsAsync();

            var onLights = lights.Where(l => l.Value.State.On == true).Select(l => l.Key).ToList();

            //foreach(var light in onLights)
            //{
            //    await lightsClient.SetStateAsync(light, new SetLightStateRequest { On = false });
            //}

            Console.WriteLine("Looking for Groups");
            var groups = await hueController.Groups.GetAllGroupsAsync();

            foreach (var group in groups)
            {
                Console.WriteLine($"Found Group: {group.Value.Name}");
            }

            var studyId = groups.Where(g => g.Value.Name == "Study").Select(g => g.Key).First();

            var builder = new GroupStateBuilder(studyId);
            await builder.TurnOff()
                    .WithTransitionTime(10)
                    .SendAsync(hueController);

            Thread.Sleep(1500);

            await builder.TurnOn()
                .WithBrightness(254)
                .SendAsync(hueController);

        }
    }
}
