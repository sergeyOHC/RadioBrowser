using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RadioBrowser.Internals;

namespace RadioBrowser.Api
{
    public class Modify
    {
        private readonly Client _client;

        internal Modify(Client client)
        {
            _client = client;
        }

        /// <summary>
        /// Increase click count
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns>Result of action</returns>
        public async Task<bool> ClickAsync(Guid uuid)
        {
            var json = (JObject) JsonConvert.DeserializeObject(await _client.GetAsync($"/url/{uuid}"));
            return json?["ok"] != null && json["ok"].Value<bool>();
        }
        
        /// <summary>
        /// Vote station
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns>Result of action</returns>
        public async Task<bool> VoteAsync(Guid uuid)
        {
            var json = (JObject) JsonConvert.DeserializeObject(await _client.GetAsync($"/vote/{uuid}"));
            return json?["ok"] != null && json["ok"].Value<bool>();
        }
    }
}