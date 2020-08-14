namespace RadioBrowser
{
    public class RadioBrowser
    {
        /// <summary>
        ///     Create RadioBrowser instance
        /// </summary>
        /// <param name="apiUrl">Optional custom API URL</param>
        public RadioBrowser(string apiUrl = null)
        {
            var converters = new Converters();
            Client = new Client(apiUrl);
            Stations = new Stations(Client, converters);
        }

        public Stations Stations { get; }
        public Client Client { get; }
    }
}