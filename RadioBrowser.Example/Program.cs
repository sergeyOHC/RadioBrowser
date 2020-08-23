using System;
using System.Linq;
using System.Threading.Tasks;
using RadioBrowser.Models;

namespace RadioBrowser.Example
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            MainAsync().Wait();
        }

        private static async Task MainAsync()
        {
            // Initialization
            var radioBrowser = new RadioBrowserClient();

            // Searching by name
            var searchByName = await radioBrowser.Search.ByNameAsync("tofu radio");
            Console.WriteLine(searchByName.First().Name); 
            Console.WriteLine("");
            
            // Advanced searching
            var advancedSearch = await radioBrowser.Search.AdvancedAsync(new AdvancedSearchOptions
            {
                Language = "english",
                TagList = "news"
            });
            Console.WriteLine(advancedSearch.First().Name);
            Console.WriteLine("");
            
            // Getting top stations
            var topByVotes = await radioBrowser.Stations.GetByVotesAsync(10);

            foreach (var station in topByVotes)
            {
                Console.WriteLine(station.Name);
            }
            Console.WriteLine("");

            // Getting codecs list
            var codecs = await radioBrowser.Lists.GetCodecsAsync();
            foreach (var codec in codecs)
            {
                Console.WriteLine($"{codec.Name} - {codec.Stationcount}");
            }
        }
    }
}