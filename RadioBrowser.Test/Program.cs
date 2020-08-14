using System;
using System.Diagnostics;
using System.Linq;

namespace RadioBrowser.Test
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var radioBrowser = new RadioBrowser();
            var countries = radioBrowser.Lists.GetStatesAsync().GetAwaiter().GetResult();

            foreach (var country in countries)
            {
                Console.WriteLine(country.Name);
            }
            
        }
    }
}