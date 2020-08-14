using System;
using System.ComponentModel;

namespace RadioBrowser.Test
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var client = new Client();
            Console.WriteLine(client.ApiUrl);
            var station = client.Stations.SearchByNameAsync("tofu").GetAwaiter().GetResult()[0];
            
            foreach(PropertyDescriptor descriptor in TypeDescriptor.GetProperties(station))
            {
                var name=descriptor.Name;
                var value=descriptor.GetValue(station);
                Console.WriteLine("{0}={1}",name,value);
            }
        }
    }
}