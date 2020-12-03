using System;

namespace RadioBrowser.Models
{
    /// <summary>
    ///     New station model.
    /// </summary>
    public class NewStation
    {
        /// <summary>
        ///     MANDATORY, the name of the radio station. Max 400 chars.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     MANDATORY, the URL of the station.
        /// </summary>
        public Uri Url { get; set; }

        /// <summary>
        ///     The homepage URL of the station.
        /// </summary>
        public Uri Homepage { get; set; }

        /// <summary>
        ///     The URL of an image file (jpg or png).
        /// </summary>
        public Uri Favicon { get; set; }

        /// <summary>
        ///     The name of the country where the radio station is located.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        ///     The 2 letter countrycode of the country where the radio station is located.
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        ///     The 2 letter countrycode of the country where the radio station is located.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        ///     The main language used in spoken text parts of the radio station.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        ///     A list of tags separated by commas to describe the station.
        /// </summary>
        public string Tags { get; set; }
    }
}