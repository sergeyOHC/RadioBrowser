using System;
using System.Threading.Tasks;
using RadioBrowser.Internals;
using RadioBrowser.Models;

namespace RadioBrowser.Api
{
    public class Modify
    {
        private readonly Converters _converters;
        private readonly HttpClient _httpClient;

        internal Modify(HttpClient httpClient, Converters converters)
        {
            _httpClient = httpClient;
            _converters = converters;
        }

        /// <summary>
        ///     Increase click count.
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns>Result of action</returns>
        public async Task<ClickResult> ClickAsync(Guid uuid)
        {
            var json = await _httpClient.GetAsync($"/url/{uuid}");
            return _converters.ToClickResult(json);
        }

        /// <summary>
        ///     Vote station.
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns>Result of action</returns>
        public async Task<ActionResult> VoteAsync(Guid uuid)
        {
            var json = await _httpClient.GetAsync($"/vote/{uuid}");
            return _converters.ToActionResult(json);
        }

        /// <summary>
        ///     Add new station.
        /// </summary>
        /// <param name="newStation">New station object</param>
        /// <returns>Result of action</returns>
        public async Task<AddStationResult> AddStationAsync(NewStation newStation)
        {
            var json = await _httpClient.GetAsync($"json/add/{Converters.GetQueryString(newStation)}");
            return _converters.ToAddStationResult(json);
        }
    }
}