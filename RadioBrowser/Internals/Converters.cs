using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Web;
using RadioBrowser.Models;

namespace RadioBrowser.Internals
{
    internal class Converters
    {
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        internal Converters()
        {
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                IgnoreNullValues = true
            };
        }

        internal List<StationInfo> ToStationsList(string json)
        {
            return JsonSerializer.Deserialize<List<StationInfo>>(json, _jsonSerializerOptions);
        }

        internal List<NameAndCount> ToNameAndCountList(string json)
        {
            return JsonSerializer.Deserialize<List<NameAndCount>>(json, _jsonSerializerOptions);
        }

        internal List<State> ToStatesList(string json)
        {
            return JsonSerializer.Deserialize<List<State>>(json, _jsonSerializerOptions);
        }

        internal ActionResult ToActionResult(string json)
        {
            return JsonSerializer.Deserialize<ActionResult>(json, _jsonSerializerOptions);
        }

        internal ClickResult ToClickResult(string json)
        {
            return JsonSerializer.Deserialize<ClickResult>(json, _jsonSerializerOptions);
        }

        internal AddStationResult ToAddStationResult(string json)
        {
            return JsonSerializer.Deserialize<AddStationResult>(json, _jsonSerializerOptions);
        }

        internal static string GetQueryString(object obj)
        {
            var properties = obj.GetType()
                .GetProperties()
                .Where(p => p.GetValue(obj, null) != null)
                .Select(p =>
                    char.ToLower(p.Name[0]) + p.Name.Substring(1) + "=" +
                    HttpUtility.UrlEncode(p.GetValue(obj, null)?.ToString()));

            return string.Join("&", properties.ToArray());
        }
    }
}