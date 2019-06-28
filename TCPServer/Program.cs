using Microsoft.Owin.Hosting;
using System;

namespace TCPServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string ip = "localhost:10833";
            string domainAddress = $"http://{ip}";

            using (WebApp.Start(url: domainAddress))
            {
                Console.WriteLine("Service Hosted on " + ip);
                System.Threading.Thread.Sleep(-1);
            }
        }
    }
}