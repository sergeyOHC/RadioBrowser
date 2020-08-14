using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using RadioBrowser.Internals;
using RadioBrowser.Models;

namespace RadioBrowser.Api
{
    public class Search
    {
        private readonly Client _client;
        private readonly Converters _converters;

        internal Search(Client client, Converters converters)
        {
            _client = client;
            _converters = converters;
        }

        /// <summary>
        /// Advanced search
        /// </summary>
        /// <param name="searchOptions">Advanced search options</param>
        /// <returns>List of stations</returns>
        public async Task<List<StationInfo>> AdvancedAsync(AdvancedSearchOptions searchOptions)
        {
            var json = await _client.GetAsync($"stations/search?{GetQueryString(searchOptions)}");
            return _converters.ToStationsList(json);
        }
        
        /// <summary>
        ///     Search stations by name
        /// </summary>
        /// <param name="name">Station name</param>
        /// <returns>List of stations</returns>
        public async Task<List<StationInfo>> ByNameAsync(string name)
        {
            var json = await _client.GetAsync($"stations/search?name={name}");
            return _converters.ToStationsList(json);
        }

        /// <summary>
        /// Search by UUID
        /// </summary>
        /// <param name="uuid">Stations UUID</param>
        /// <returns>List of stations</returns>
        public async Task<List<StationInfo>> ByUuidAsync(Guid uuid)
        {
            var json = await _client.GetAsync($"stations/byuuid?uuids={uuid.ToString()}");
            return _converters.ToStationsList(json);
        }
        
        /// <summary>
        /// Search by URL
        /// </summary>
        /// <param name="url">Station URL</param>
        /// <returns>List of stations</returns>
        public async Task<List<StationInfo>> ByUrlAsync(string url)
        {
            var json = await _client.GetAsync($"stations/byurl?url={url}");
            return _converters.ToStationsList(json);
        }
        
        private static string GetQueryString(object obj)
        {
            var properties = obj.GetType()
                .GetProperties()
                .Where(p => p.GetValue(obj, null) != null)
                .Select(p => char.ToLower(p.Name[0]) + p.Name.Substring(1) + "=" + HttpUtility.UrlEncode(p.GetValue(obj, null).ToString()));

            return string.Join("&", properties.ToArray());
        }
    }
}