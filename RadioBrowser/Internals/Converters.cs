using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RadioBrowser.Models;

namespace RadioBrowser.Internals
{
    internal class Converters
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        internal Converters()
        {
            _jsonSerializerSettings = new JsonSerializerSettings
            {
                Error = HandleDeserializationError
            };
        }

        internal List<StationInfo> ToStationsList(string json)
        {
            return JsonConvert.DeserializeObject<List<StationInfo>>(json, _jsonSerializerSettings);
        }

        internal List<Country> ToCountriesList(string json)
        {
            return JsonConvert.DeserializeObject<List<Country>>(json, _jsonSerializerSettings);
        }

        private static void HandleDeserializationError(object sender, ErrorEventArgs errorArgs)
        {
            var currentError = errorArgs.ErrorContext.Error.Message;
            Trace.WriteLine(currentError);
            errorArgs.ErrorContext.Handled = true;
        }
    }
}