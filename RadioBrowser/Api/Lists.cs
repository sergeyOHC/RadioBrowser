// ReSharper disable ConvertIfStatementToReturnStatement

using System.Collections.Generic;
using System.Threading.Tasks;
using RadioBrowser.Internals;
using RadioBrowser.Models;

namespace RadioBrowser.Api
{
    public class Lists
    {
        private readonly Internals.HttpClient _httpClient;
        private readonly Converters _converters;

        internal Lists(Internals.HttpClient httpClient, Converters converters)
        {
            _httpClient = httpClient;
            _converters = converters;
        }

        /// <summary>
        ///     Get list of all stations.
        /// </summary>
        /// <returns>List of stations</returns>
        public async Task<List<StationInfo>> GetAllStationsAsync()
        {
            return _converters.ToStationsList(await _httpClient.GetAsync("stations"));
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
                return _converters.ToNameAndCountList(await _httpClient.GetAsync("countries"));
            }

            return _converters.ToNameAndCountList(await _httpClient.GetAsync($"countries/{filter}"));
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
                return _converters.ToNameAndCountList(await _httpClient.GetAsync("countrycodes"));
            }

            return _converters.ToNameAndCountList(await _httpClient.GetAsync($"countrycodes/{filter}"));
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
                return _converters.ToNameAndCountList(await _httpClient.GetAsync("codecs"));
            }

            return _converters.ToNameAndCountList(await _httpClient.GetAsync($"codecs/{filter}"));
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
                return _converters.ToStatesList(await _httpClient.GetAsync("states"));
            }

            return _converters.ToStatesList(await _httpClient.GetAsync($"states/{filter}"));
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
                return _converters.ToNameAndCountList(await _httpClient.GetAsync("languages"));
            }

            return _converters.ToNameAndCountList(await _httpClient.GetAsync($"languages/{filter}"));
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
                return _converters.ToNameAndCountList(await _httpClient.GetAsync("tags"));
            }

            return _converters.ToNameAndCountList(await _httpClient.GetAsync($"tags/{filter}"));
        }
    }
}