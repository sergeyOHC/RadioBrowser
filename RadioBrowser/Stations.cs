using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RadioBrowser
{
    public class Stations
    {
        private readonly Client _client;

        public Stations(Client client)
        {
            _client = client;
        }

        public async Task<List<StationInfo>> SearchByNameAsync(string name)
        {
            var json = await _client.GetAsync($"stations/search?name={name}");
            return JsonConvert.DeserializeObject<List<StationInfo>>(json);
        }
    }
}