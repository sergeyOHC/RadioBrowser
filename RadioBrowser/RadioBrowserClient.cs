using RadioBrowser.Api;
using RadioBrowser.Internals;

namespace RadioBrowser
{
    public class RadioBrowserClient : IRadioBrowserClient
    {
        /// <summary>
        ///     Create RadioBrowser instance
        /// </summary>
        /// <param name="apiUrl">Optional custom API URL</param>
        /// <param name="customUserAgent">Optional custom user agent</param>
        public RadioBrowserClient(string apiUrl = null, string customUserAgent = null)
        {
            var converters = new Converters();
            HttpClient = new HttpClient(apiUrl, customUserAgent);
            Search = new Search(HttpClient, converters);
            Lists = new Lists(HttpClient, converters);
            Stations = new Stations(HttpClient, converters);
            Modify = new Modify(HttpClient, converters);
        }

        public Search Search { get; }
        public Lists Lists { get; }
        public Stations Stations { get; }
        public HttpClient HttpClient { get; }
        public Modify Modify { get; }
    }
}