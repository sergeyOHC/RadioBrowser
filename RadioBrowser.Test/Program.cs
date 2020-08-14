using System;
using System.Linq;

namespace RadioBrowser.Test
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var radioBrowser = new RadioBrowser();
            Console.WriteLine(radioBrowser.Client.ApiUrl);

            var station = radioBrowser.Stations.SearchByNameAsync("test").GetAwaiter().GetResult().First();

            Console.WriteLine(station.Name);
        }
    }
}