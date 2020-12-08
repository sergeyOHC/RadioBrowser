using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using RadioBrowser.Internals.JsonConverters;

namespace RadioBrowser.Models
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class StationInfo
    {
        /// <summary>
        ///     A globally unique identifier for the change of the station information.
        /// </summary>
        public Guid ChangeUuid { get; set; }

        /// <summary>
        ///     A globally unique identifier for the station.
        /// </summary>
        public Guid StationUuid { get; set; }

        /// <summary>
        ///     The name of the station.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     The stream URL provided by the user.
        /// </summary>
        [JsonConverter(typeof(UriConverter))]
        public Uri Url { get; set; }

        /// <summary>
        ///     An automatically "resolved" stream URL.
        ///     Things resolved are playlists (M3U/PLS/ASX...), HTTP redirects (Code 301/302).
        ///     This link is especially useful if you use this API from a platform that
        ///     is not able to do a resolve on its own (e.g. JavaScript in browser)
        ///     or you just don't want to invest the time in decoding playlists yourself.
        /// </summary>
        [JsonPropertyName("url_resolved")]
        [JsonConverter(typeof(UriConverter))]
        public Uri UrlResolved { get; set; }

        /// <summary>
        ///     URL to the homepage of the stream,
        ///     so you can direct the user to a page with more information about the stream.
        /// </summary>
        [JsonConverter(typeof(UriConverter))]
        public Uri Homepage { get; set; }

        /// <summary>
        ///     URL to an icon or picture that represents the stream. (PNG, JPG)
        /// </summary>
        [JsonConverter(typeof(UriConverter))]
        public Uri Favicon { get; set; }

        /// <summary>
        ///     Tags of the stream with more information about it.
        /// </summary>
        [JsonConverter(typeof(ListConverter))]
        public List<string> Tags { get; set; }

        /// <summary>
        ///     Official country codes as in ISO 3166-1 alpha-2.
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        ///     Languages that are spoken in this stream.
        /// </summary>
        [JsonConverter(typeof(ListConverter))]
        public List<string> Language { get; set; }

        /// <summary>
        ///     Number of votes for this station. This number is by server and only ever increases.
        ///     It will never be reset to 0.
        /// </summary>
        public int Votes { get; set; }

        /// <summary>
        ///     Last time when the stream information was changed in the database.
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime LastChangeTime { get; set; }

        /// <summary>
        ///     The codec of this stream recorded at the last check.
        /// </summary>
        public string Codec { get; set; }

        /// <summary>
        ///     The bitrate of this stream recorded at the last check.
        /// </summary>
        public int Bitrate { get; set; }

        /// <summary>
        ///     Mark if this stream is using HLS distribution or non-HLS.
        /// </summary>
        [JsonConverter(typeof(BoolConverter))]
        public bool Hls { get; set; }

        /// <summary>
        ///     The current online/offline state of this stream.
        ///     This is a value calculated from multiple measure points in the internet.
        ///     The test servers are located in different countries. It is a majority vote.
        /// </summary>
        [JsonConverter(typeof(BoolConverter))]
        public bool LastCheckOk { get; set; }

        /// <summary>
        ///     The last time when any radio-browser server checked the online state of this stream.
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime LastCheckTime { get; set; }

        /// <summary>
        ///     The last time when the stream was checked for the online status with a positive result.
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime LastCheckOkTime { get; set; }

        /// <summary>
        ///     The last time when this server checked the online state and the metadata of this stream.
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime LastLocalCheckTime { get; set; }

        /// <summary>
        ///     The time of the last click recorded for this stream.
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime ClickTimestamp { get; set; }

        /// <summary>
        ///     Clicks within the last 24 hours.
        /// </summary>
        public int ClickCount { get; set; }

        /// <summary>
        ///     The difference of the click counts within the last 2 days.
        ///     Positive values mean an increase, negative a decrease of clicks.
        /// </summary>
        public int ClickTrend { get; set; }
    }
}