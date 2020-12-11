using RadioBrowser.Api;
using RadioBrowser.Internals;

namespace RadioBrowser
{
    public interface IRadioBrowserClient
    {
        public Search Search { get; }
        public Lists Lists { get; }
        public Stations Stations { get; }
        public HttpClient HttpClient { get; }
        public Modify Modify { get; }
    }
}