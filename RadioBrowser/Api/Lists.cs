// ReSharper disable ConvertIfStatementToReturnStatement

using System.Collections.Generic;
using System.Threading.Tasks;
using RadioBrowser.Internals;
using RadioBrowser.Models;

namespace RadioBrowser.Api
{
    public class Lists
    {
        private readonly Client _client;
        private readonly Converters _converters;

        internal Lists(Client client, Converters converters)
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
            return _converters.ToStationsList(await _client.GetAsync("stations"));
        }

        /// <summary>
        ///     Get list of countries.
        /// </summary>
        /// <param name="filter">Optional: filter</param>
        /// <returns>List of countries</returns>
        public async Task<List<NameAndCount>> GetCountriesAsync(string filter = null)
        {
            if (filter == null)
            {
                return _converters.ToNameAndCountList(await _client.GetAsync($"countries/{filter}"));
            }
            return _converters.ToNameAndCountList(await _client.GetAsync("countries"));
        }

        /// <summary>
        /// Get list of country codes.
        /// </summary>
        /// <param name="filter">Optional: filter</param>
        /// <returns>List of country codes</returns>
        public async Task<List<NameAndCount>> GetCountriesCodesAsync(string filter = null)
        {
            if (filter == null)
            {
                return _converters.ToNameAndCountList(await _client.GetAsync($"countrycodes/{filter}"));
            }
            return _converters.ToNameAndCountList(await _client.GetAsync("countrycodes"));
        }

        /// <summary>
        /// Get list of codecs.
        /// </summary>
        /// <param name="filter">Optional: filter</param>
        /// <returns>List of codecs</returns>
        public async Task<List<NameAndCount>> GetCodecsAsync(string filter = null)
        {
            if (filter == null)
            {
                return _converters.ToNameAndCountList(await _client.GetAsync($"codecs/{filter}"));
            }
            return _converters.ToNameAndCountList(await _client.GetAsync("codecs"));
        }

        /// <summary>
        /// Get list of states.
        /// </summary>
        /// <param name="filter">Optional: country or other filter</param>
        /// <returns>List of states</returns>
        public async Task<List<State>> GetStatesAsync(string filter = null)
        {
            if (filter == null)
            {
                return _converters.ToStatesList(await _client.GetAsync("states"));
            }
            return _converters.ToStatesList(await _client.GetAsync($"states/{filter}"));
        }
    }
}