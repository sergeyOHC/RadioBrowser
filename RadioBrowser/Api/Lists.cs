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
            var json = await _client.GetAsync("stations");
            return _converters.ToStationsList(json);
        }
        
        /// <summary>
        ///     Get list of countries.
        /// </summary>
        /// <returns>List of countries</returns>
        public async Task<List<Country>> GetCountriesAsync()
        {
            var json = await _client.GetAsync("countries");
            return _converters.ToCountriesList(json);
        }
        
        /// <summary>
        /// Get List of country codes.
        /// </summary>
        /// <returns>List of country codes</returns>
        public async Task<List<Country>> GetCountriesCodesAsync()
        {
            var json = await _client.GetAsync("countrycodes");
            return _converters.ToCountriesList(json);
        }
    }
}