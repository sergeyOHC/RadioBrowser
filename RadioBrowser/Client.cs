using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace RadioBrowser
{
    public class Client
    {
        private readonly HttpClient _httpClient;

        internal Client(string apiUrl)
        {
            ApiUrl = apiUrl ?? GetRadioBrowserApiUrl();
            _httpClient = new HttpClient();
        }

        /// <summary>
        ///     Currently used API URL
        /// </summary>
        public string ApiUrl { get; }

        private static string GetRadioBrowserApiUrl()
        {
            // Get fastest ip of dns
            const string baseUrl = @"all.api.radio-browser.info";
            var ips = Dns.GetHostAddresses(baseUrl);
            var lastRoundTripTime = long.MaxValue;
            var searchUrl = @"de1.api.radio-browser.info";

            foreach (var ipAddress in ips)
            {
                var reply = new Ping().Send(ipAddress);
                if (reply == null || reply.RoundtripTime >= lastRoundTripTime) continue;
                lastRoundTripTime = reply.RoundtripTime;
                searchUrl = ipAddress.ToString();
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