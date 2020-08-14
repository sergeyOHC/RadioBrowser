using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace RadioBrowser
{
    public class Stations
    {
        private readonly Client _client;

        public Stations(Client client)
        {
            _client = client;
        }

        public async Task<List<StationInfo>> GetAllAsync()
        {
            var json = await _client.GetAsync($"stations");
            return JsonConvert.DeserializeObject<List<StationInfo>>(json, new JsonSerializerSettings
            {
                Error = HandleDeserializationError
            });
        }

        /// <summary>
        /// Search stations by name
        /// </summary>
        /// <param name="name">Station name</param>
        /// <returns>List of results</returns>
        public async Task<List<StationInfo>> SearchByNameAsync(string name)
        {
            var json = await _client.GetAsync($"stations/search?name={name}");
            return JsonConvert.DeserializeObject<List<StationInfo>>(json);
        }
        
        private static void HandleDeserializationError(object sender, ErrorEventArgs errorArgs)
        {
            var currentError = errorArgs.ErrorContext.Error.Message;
            Trace.WriteLine(currentError);
            errorArgs.ErrorContext.Handled = true;
        }
    }
}