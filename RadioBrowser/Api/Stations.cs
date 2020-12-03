// ReSharper disable ConvertIfStatementToReturnStatement

using System.Collections.Generic;
using System.Threading.Tasks;
using RadioBrowser.Internals;
using RadioBrowser.Models;

namespace RadioBrowser.Api
{
    public class Stations
    {
        private readonly Converters _converters;
        private readonly HttpClient _httpClient;

        internal Stations(HttpClient httpClient, Converters converters)
        {
            _httpClient = httpClient;
            _converters = converters;
        }

        /// <summary>
        ///     Get stations that are clicked the most.
        /// </summary>
        /// <param name="limit">Optional limit</param>
        /// <returns>List of stations</returns>
        public async Task<List<StationInfo>> GetByClicksAsync(uint limit = 0)
        {
            if (limit == 0) return _converters.ToStationsList(await _httpClient.GetAsync("stations/topclick"));

            return _converters.ToStationsList(await _httpClient.GetAsync($"stations/topclick/{limit}"));
        }

        /// <summary>
        ///     Get stations with highest votes.
        /// </summary>
        /// <param name="limit"></param>
        /// <returns>List of stations</returns>
        public async Task<List<StationInfo>> GetByVotesAsync(uint limit = 0)
        {
            if (limit == 0) return _converters.ToStationsList(await _httpClient.GetAsync("stations/topvote"));

            return _converters.ToStationsList(await _httpClient.GetAsync($"stations/topvote/{limit}"));
        }

        /// <summary>
        ///     Get stations by recent clicks.
        /// </summary>
        /// <param name="limit"></param>
        /// <returns>List of stations</returns>
        public async Task<List<StationInfo>> GetByRecentClickAsync(uint limit = 0)
        {
            if (limit == 0) return _converters.ToStationsList(await _httpClient.GetAsync("stations/lastclick"));

            return _converters.ToStationsList(await _httpClient.GetAsync($"stations/lastclick/{limit}"));
        }

        /// <summary>
        ///     Get recently changed stations.
        /// </summary>
        /// <param name="limit"></param>
        /// <returns>List of stations</returns>
        public async Task<List<StationInfo>> GetByLastChangesAsync(uint limit = 0)
        {
            if (limit == 0) return _converters.ToStationsList(await _httpClient.GetAsync("stations/lastchange"));

            return _converters.ToStationsList(await _httpClient.GetAsync($"stations/lastchange/{limit}"));
        }
    }
}