using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RadioBrowser.Internals.JsonConverters
{
    public class ListConverter : JsonConverter<List<string>>
    {
        public override List<string> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var inputString = reader.GetString();
            return inputString?.Split(',').Select(s => s.Trim()).ToList();
        }

        public override void Write(Utf8JsonWriter writer, List<string> value, JsonSerializerOptions options)
        {
            throw new NotSupportedException();
        }
    }
}