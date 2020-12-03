using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RadioBrowser.Internals
{
    public class DateTimeConverter :JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var inputString = reader.GetString();
            var dateTime = DateTime.ParseExact(inputString, "yyyy-MM-dd HH:mm:ss", CultureInfo.CurrentCulture);
            return dateTime;
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            throw new NotSupportedException();
        }
    }
}