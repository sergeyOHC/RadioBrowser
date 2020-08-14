// ReSharper disable ConvertIfStatementToReturnStatement
using System.Collections.Generic;
using System.Threading.Tasks;
using RadioBrowser.Internals;

namespace RadioBrowser.Api
{
    public class Stations
    {
        private readonly Client _client;
        private readonly Converters _converters;

        internal Stations(Client client, Converters converters)
        {
            _client = client;
            _converters = converters;
        }

        /// <summary>
        ///     Get list of all stations.
        /// </summary>
        /// <returns>List of stations</returns>
        public async Task<List<StationInfo>> GetAllAsync()
        {
            var json = await _client.GetAsync("stations");
            return _converters.ToStationsList(json);
        }

        /// <summary>
        ///     Get stations that are clicked the most.
        /// </summary>
        /// <param name="limit">Optional limit</param>
        /// <returns>List of stations</returns>
        public async Task<List<StationInfo>> GetByClicksAsync(uint limit = 0)
        {
            if (limit == 0)
            {
                return _converters.ToStationsList(await _client.GetAsync("stations/topclick"));
            }

            return _converters.ToStationsList(await _client.GetAsync($"stations/topclick/{limit}"));
        }
        
        /// <summary>
        ///     Get stations with highest votes.
        /// </summary>
        /// <param name="limit"></param>
        /// <returns>List of stations</returns>
        public async Task<List<StationInfo>> GetByVotesAsync(uint limit = 0)
        {
            if (limit == 0)
            {
                return _converters.ToStationsList(await _client.GetAsync("stations/topvote"));
            }

            return _converters.ToStationsList(await _client.GetAsync($"stations/topvote/{limit}"));
        }
        
        /// <summary>
        ///     Get stations by recent clicks.
        /// </summary>
        /// <param name="limit"></param>
        /// <returns>List of stations</returns>
        public async Task<List<StationInfo>> GetByRecentClickAsync(uint limit = 0)
        {
            if (limit == 0)
            {
                return _converters.ToStationsList(await _client.GetAsync("stations/lastclick"));
            }

            return _converters.ToStationsList(await _client.GetAsync($"stations/lastclick/{limit}"));
        }
        
        /// <summary>
        ///     Get recently changed stations.
        /// </summary>
        /// <param name="limit"></param>
        /// <returns>List of stations</returns>
        public async Task<List<StationInfo>> GetByLastChangesAsync(uint limit = 0)
        {
            if (limit == 0)
            {
                return _converters.ToStationsList(await _client.GetAsync("stations/lastchange"));
            }

            return _converters.ToStationsList(await _client.GetAsync($"stations/lastchange/{limit}"));
        }
    }
}