using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace RadioBrowser.Internals
{
    public class HttpClient
    {
        private readonly System.Net.Http.HttpClient _httpClient;

        internal HttpClient(string apiUrl, string userAgent)
        {
            ApiUrl = apiUrl ?? GetRadioBrowserApiUrl();
            UserAgent = userAgent ?? "RadioBrowser.NET Library/0.4";

            _httpClient = new System.Net.Http.HttpClient();
            _httpClient.DefaultRequestHeaders.Add("User-Agent", UserAgent);
        }

        /// <summary>
        ///     Currently used API URL
        /// </summary>
        public string ApiUrl { get; }

        /// <summary>
        ///     Currently used user agent
        /// </summary>
        public string UserAgent { get; }

        private static string GetRadioBrowserApiUrl()
        {
            // Get fastest ip of dns
            const string baseUrl = @"all.api.radio-browser.info";
            var ips = Dns.GetHostAddresses(baseUrl);
            var lastRoundTripTime = long.MaxValue;
            var searchUrl = @"de1.api.radio-browser.info";

            foreach (var ipAddress in ips)
                try
                {
                    var reply = new Ping().Send(ipAddress);
                    if (reply == null || reply.RoundtripTime >= lastRoundTripTime) continue;
                    lastRoundTripTime = reply.RoundtripTime;
                    searchUrl = ipAddress.ToString();
                }
                catch (SocketException)
                {
                    Trace.Write("Cannot ping socket");
                }

            // Get clean name
            var hostEntry = Dns.GetHostEntry(searchUrl);
            if (!string.IsNullOrEmpty(hostEntry.HostName)) searchUrl = hostEntry.HostName;

            return searchUrl;
        }

        internal async Task<string> GetAsync(string endpoint)
        {
            var response = await _httpClient.GetAsync($"https://{ApiUrl}/json/{endpoint}");
            return response.IsSuccessStatusCode ? await response.Content.ReadAsStringAsync() : null;
        }
    }
}