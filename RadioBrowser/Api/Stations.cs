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
        ///     Get list of all stations
        /// </summary>
        /// <returns>List of stations</returns>
        public async Task<List<StationInfo>> GetAllAsync()
        {
            var json = await _client.GetAsync("stations");
            return _converters.ToStationsList(json);
        }
    }
}