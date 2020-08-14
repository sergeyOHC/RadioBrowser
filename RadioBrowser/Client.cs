using System.Net;
using System.Net.NetworkInformation;

namespace RadioBrowser
{
    public class Client
    {
        /// <summary>
        /// Currently used API URL
        /// </summary>
        public string ApiUrl { get;}

        /// <summary>
        /// Initialize client with custom API URL
        /// </summary>
        /// <param name="apiUrl"></param>
        public Client(string apiUrl)
        {
            ApiUrl = apiUrl;
        }

        /// <summary>
        /// Initialize client
        /// </summary>
        public Client()
        {
            ApiUrl = GetRadioBrowserApiUrl();
        }

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
            if (!string.IsNullOrEmpty(hostEntry.HostName))
            {
                searchUrl = hostEntry.HostName;
            }

            return searchUrl;
        }
    }
}