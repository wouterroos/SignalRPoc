using System;
using System.Threading;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using Owin;
using SignalRPoc.Shared;

namespace SignalRPoc.Server
{
    public class MyHub : Hub
    {
        public void Register(string name)
        {
            Console.WriteLine($"Recieved fingerprint registration request from {name}");
            Clients.All.sendMessage($"Hello {name}, please put your finger on the scanner!");

            //mock fingerprint scanning
            Thread.Sleep(2000);

            //mock checksum generation
            Clients.All.sendMessage($"Generating fingerprint checksum for {name}...");
            Thread.Sleep(2000);

            //mock data access.
            Clients.All.sendMessage($"Writing fingerprint checksum for {name} to database...");
            Thread.Sleep(1000);

            Clients.All.sendMessage("Done!");
        }
    }

    internal static class Program
    {
        private static void Main()
        {
            using (WebApp.Start(Settings.SignalREndpoint))
            {
                Console.WriteLine("Server running on {0}", Settings.SignalREndpoint);
                Console.ReadLine();
            }
        }
    }

    internal class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var hubConfiguration = new HubConfiguration {EnableDetailedErrors = true};

            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR(hubConfiguration);
        }
    }
}