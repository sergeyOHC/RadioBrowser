using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RadioBrowser.Internals;
using RadioBrowser.Models;

namespace RadioBrowser.Api
{
    public class Search
    {
        private readonly Converters _converters;
        private readonly HttpClient _httpClient;

        internal Search(HttpClient httpClient, Converters converters)
        {
            _httpClient = httpClient;
            _converters = converters;
        }

        /// <summary>
        ///     Advanced search
        /// </summary>
        /// <param name="searchOptions">Advanced search options</param>
        /// <returns>List of stations</returns>
        public async Task<List<StationInfo>> AdvancedAsync(AdvancedSearchOptions searchOptions)
        {
            var json = await _httpClient.GetAsync($"stations/search?{Converters.GetQueryString(searchOptions)}");
            return _converters.ToStationsList(json);
        }

        /// <summary>
        ///     Search stations by name
        /// </summary>
        /// <param name="name">Station name</param>
        /// <returns>List of stations</returns>
        public async Task<List<StationInfo>> ByNameAsync(string name)
        {
            var json = await _httpClient.GetAsync($"stations/search?name={name}");
            return _converters.ToStationsList(json);
        }

        /// <summary>
        ///     Search by UUID
        /// </summary>
        /// <param name="uuid">Stations UUID</param>
        /// <returns>List of stations</returns>
        public async Task<List<StationInfo>> ByUuidAsync(Guid uuid)
        {
            var json = await _httpClient.GetAsync($"stations/byuuid?uuids={uuid.ToString()}");
            return _converters.ToStationsList(json);
        }

        /// <summary>
        ///     Search by URL
        /// </summary>
        /// <param name="url">Station URL</param>
        /// <returns>List of stations</returns>
        public async Task<List<StationInfo>> ByUrlAsync(string url)
        {
            var json = await _httpClient.GetAsync($"stations/byurl?url={url}");
            return _converters.ToStationsList(json);
        }
    }
}