using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
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

        internal ActionResult ToActionResult(string json)
        {
            return JsonConvert.DeserializeObject<ActionResult>(json, _jsonSerializerSettings);
        }
        
        internal ClickResult ToClickResult(string json)
        {
            return JsonConvert.DeserializeObject<ClickResult>(json, _jsonSerializerSettings);
        }
        
        internal AddStationResult ToAddStationResult(string json)
        {
            return JsonConvert.DeserializeObject<AddStationResult>(json, _jsonSerializerSettings);
        }
        
        internal string GetQueryString(object obj)
        {
            var properties = obj.GetType()
                .GetProperties()
                .Where(p => p.GetValue(obj, null) != null)
                .Select(p => char.ToLower(p.Name[0]) + p.Name.Substring(1) + "=" + HttpUtility.UrlEncode(p.GetValue(obj, null).ToString()));

            return string.Join("&", properties.ToArray());
        }
        
        private static void HandleDeserializationError(object sender, ErrorEventArgs errorArgs)
        {
            var currentError = errorArgs.ErrorContext.Error.Message;
            Trace.WriteLine(currentError);
            errorArgs.ErrorContext.Handled = true;
        }
    }
}