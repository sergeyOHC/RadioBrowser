using System;

namespace RadioBrowser.Test
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var client = new Client();
            Console.WriteLine(client.ApiUrl);
        }
    }
}