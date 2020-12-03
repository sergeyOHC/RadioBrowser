using System;
using System.ComponentModel;
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
            var searchByName = await radioBrowser.Search.ByNameAsync("lainchan");

            foreach(PropertyDescriptor descriptor in TypeDescriptor.GetProperties(searchByName.First()))
            {
                var name=descriptor.Name;
                var value=descriptor.GetValue(searchByName.First());
                Console.WriteLine("{0}={1}",name,value);
            }
        }
    }
}