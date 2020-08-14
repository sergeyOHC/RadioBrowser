namespace RadioBrowser.Models
{
    public class AdvancedSearchOptions
    {
        /// <summary>
        ///     OPTIONAL, name of the station.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     OPTIONAL. True: only exact matches, otherwise all matches.
        /// </summary>
        public string NameExact { get; set; }

        /// <summary>
        ///     OPTIONAL, country of the station
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        ///     OPTIONAL. True: only exact matches, otherwise all matches.
        /// </summary>
        public bool? CountryExact { get; set; }

        /// <summary>
        ///     OPTIONAL, 2-digit countrycode of the station (ISO 3166-1 alpha-2).
        /// </summary>
        public string Countrycode { get; set; }

        /// <summary>
        ///     OPTIONAL, state of the station.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        ///     OPTIONAL. True: only exact matches, otherwise all matches.
        /// </summary>
        public bool? StateExact { get; set; }

        /// <summary>
        ///     OPTIONAL, language of the station.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        ///     OPTIONAL. True: only exact matches, otherwise all matches.
        /// </summary>
        public string LanguageExact { get; set; }

        /// <summary>
        ///     OPTIONAL. True: only exact matches, otherwise all matches.
        /// </summary>
        public bool? TagExact { get; set; }

        /// <summary>
        ///     OPTIONAL. , a comma-separated list of tag.
        ///     It can also be an array of string in JSON HTTP POST parameters.
        ///     All tags in list have to match.
        /// </summary>
        public string TagList { get; set; }

        /// <summary>
        ///     OPTIONAL, codec of the station
        /// </summary>
        public string Codec { get; set; }

        /// <summary>
        ///     OPTIONAL, minimum of kbps for bitrate field of stations in result
        /// </summary>
        public uint? BitrateMin { get; set; }

        /// <summary>
        ///     OPTIONAL, maximum of kbps for bitrate field of stations in result
        /// </summary>
        public uint? BitrateMax { get; set; }

        /// <summary>
        ///     OPTIONAL, name of the attribute the result list will be sorted by
        /// </summary>
        public string Order { get; set; }

        /// <summary>
        ///     OPTIONAL, reverse the result list if set to true.
        /// </summary>
        public bool? Reverse { get; set; }

        /// <summary>
        ///     OPTIONAL, starting value of the result list from the database.
        ///     For example, if you want to do paging on the server side.
        /// </summary>
        public uint? Offset { get; set; }

        /// <summary>
        ///     OPTIONAL, number of returned data rows (stations) starting with offset.
        /// </summary>
        public uint? Limit { get; set; }
    }
}