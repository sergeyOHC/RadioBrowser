using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RadioBrowser.Internals.JsonConverters
{
    public class BoolConverter : JsonConverter<bool>
    {
        public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var inputString = reader.GetInt16().ToString();
            return inputString == "1";
        }

        public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
        {
            throw new NotSupportedException();
        }
    }
}