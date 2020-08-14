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
        public async Task<List<StationInfo>> GetAllStationsAsync()
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
                return _converters.ToNameAndCountList(await _client.GetAsync("countries"));
            }

            return _converters.ToNameAndCountList(await _client.GetAsync($"countries/{filter}"));
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
                return _converters.ToNameAndCountList(await _client.GetAsync("countrycodes"));
            }

            return _converters.ToNameAndCountList(await _client.GetAsync($"countrycodes/{filter}"));
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
                return _converters.ToNameAndCountList(await _client.GetAsync("codecs"));
            }

            return _converters.ToNameAndCountList(await _client.GetAsync($"codecs/{filter}"));
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

        /// <summary>
        /// Get list of languages.
        /// </summary>
        /// <param name="filter">Optional: filter</param>
        /// <returns>List of languages</returns>
        public async Task<List<NameAndCount>> GetLanguagesAsync(string filter = null)
        {
            if (filter == null)
            {
                return _converters.ToNameAndCountList(await _client.GetAsync("languages"));
            }

            return _converters.ToNameAndCountList(await _client.GetAsync($"languages/{filter}"));
        }

        /// <summary>
        /// Get list of tags.
        /// </summary>
        /// <param name="filter">Optional: filter</param>
        /// <returns>List of tags</returns>
        public async Task<List<NameAndCount>> GetTagsAsync(string filter = null)
        {
            if (filter == null)
            {
                return _converters.ToNameAndCountList(await _client.GetAsync("tags"));
            }

            return _converters.ToNameAndCountList(await _client.GetAsync($"tags/{filter}"));
        }
    }
}