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

        internal List<NameAndCount> ToNameAndCountList(string json)
        {
            return JsonConvert.DeserializeObject<List<NameAndCount>>(json, _jsonSerializerSettings);
        }
        
        internal List<State> ToStatesList(string json)
        {
            return JsonConvert.DeserializeObject<List<State>>(json, _jsonSerializerSettings);
        }

        private static void HandleDeserializationError(object sender, ErrorEventArgs errorArgs)
        {
            var currentError = errorArgs.ErrorContext.Error.Message;
            Trace.WriteLine(currentError);
            errorArgs.ErrorContext.Handled = true;
        }
    }
}