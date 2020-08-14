using System;

namespace RadioBrowser.Test
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var radioBrowser = new RadioBrowser();
            
            var stations = radioBrowser.Search.AdvancedAsync(new AdvancedSearchOptions
            {
                Name = "test"
            }).GetAwaiter().GetResult();

            Console.WriteLine(stations.Count);

            foreach (var station in stations)
            {
                Console.WriteLine(station.Name);
            }
        }
    }
}