using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RadioBrowser.Internals;
using RadioBrowser.Models;

namespace RadioBrowser.Api
{
    public class Modify
    {
        private readonly Client _client;
        private readonly Converters _converters;

        internal Modify(Client client, Converters converters)
        {
            _client = client;
            _converters = converters;
        }

        /// <summary>
        /// Increase click count.
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns>Result of action</returns>
        public async Task<bool> ClickAsync(Guid uuid)
        {
            var json = (JObject) JsonConvert.DeserializeObject(await _client.GetAsync($"/url/{uuid}"));
            return json?["ok"] != null && json["ok"].Value<bool>();
        }
        
        /// <summary>
        /// Vote station.
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns>Result of action</returns>
        public async Task<bool> VoteAsync(Guid uuid)
        {
            var json = (JObject) JsonConvert.DeserializeObject(await _client.GetAsync($"/vote/{uuid}"));
            return json?["ok"] != null && json["ok"].Value<bool>();
        }

        /// <summary>
        /// Add new station.
        /// </summary>
        /// <param name="newStation">New station object</param>
        /// <returns>Result of action</returns>
        public async Task<AddStationResult> AddStationAsync(NewStation newStation)
        {
            var json = await _client.GetAsync($"json/add/{_converters.GetQueryString(newStation)}");
            return _converters.ToAddStationResult(json);
        }
    }
}