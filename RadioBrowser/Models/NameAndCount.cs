namespace RadioBrowser.Models
{
    public class NameAndCount
    {
        /// <summary>
        ///     Country name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Count of stations in country.
        /// </summary>
        public uint Stationcount { get; set; }
    }
}