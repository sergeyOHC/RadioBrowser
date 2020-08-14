using System.Collections.Generic;
using System.Threading.Tasks;

namespace RadioBrowser
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
        ///     Get list of all stations
        /// </summary>
        /// <returns>List of stations</returns>
        public async Task<List<StationInfo>> GetAllAsync()
        {
            var json = await _client.GetAsync("stations");
            return _converters.ToStationsList(json);
        }

        /// <summary>
        ///     Search stations by name
        /// </summary>
        /// <param name="name">Station name</param>
        /// <returns>List of stations</returns>
        public async Task<List<StationInfo>> SearchByNameAsync(string name)
        {
            var json = await _client.GetAsync($"stations/search?name={name}");
            return _converters.ToStationsList(json);
        }
    }
}