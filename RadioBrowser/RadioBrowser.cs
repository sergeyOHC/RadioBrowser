using RadioBrowser.Api;
using RadioBrowser.Internals;

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
            Search = new Search(Client, converters);
            Stations = new Stations(Client, converters);
            Modify = new Modify(Client);
        }

        public Search Search { get; }
        public Stations Stations { get; }
        public Client Client { get; }
        public Modify Modify { get; }
    }
}