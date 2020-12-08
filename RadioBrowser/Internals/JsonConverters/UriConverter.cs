using System;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RadioBrowser.Internals.JsonConverters
{
    public class UriConverter : JsonConverter<Uri>
    {
        public override Uri Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            try
            {
                return new Uri(reader.GetString()!);
            }
            catch (UriFormatException)
            {
                Trace.WriteLine("Cannot parse URI.");
                return null;
            }
        }

        public override void Write(Utf8JsonWriter writer, Uri value, JsonSerializerOptions options)
        {
            throw new NotSupportedException();
        }
    }
}