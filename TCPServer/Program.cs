using Microsoft.Owin.Hosting;
using System;
using System.Net;
using System.Net.Sockets;

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
                Console.WriteLine("HTTP: Service Hosted on " + ip + Environment.NewLine);
                System.Threading.Thread.Sleep(-1);
            }
          
        }
    }
}