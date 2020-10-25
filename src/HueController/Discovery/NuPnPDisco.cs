using PReardon.HueController.Discovery.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PReardon.HueController.Discovery
{
    public class NuPnPDisco
    {
        private const string _addressUri = "https://discovery.meethue.com/";
        public async Task<BringAddressInformation[]> Discover() 
        {
            var client = new HttpClient();

            var response = await client.GetAsync(_addressUri);
            
            if(response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return (JsonSerializer.Deserialize<BringAddressInformation[]>(content));
            }

            return null;
        }
    }
}
