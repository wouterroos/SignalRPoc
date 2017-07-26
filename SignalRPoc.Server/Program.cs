using System;
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
            Console.WriteLine($"Recieved message from {name}");
            Clients.All.sendMessage($"Hello {name}, please put your finger on the scanner!");
        }
    }

    internal static class Program
    {
        private static void Main()
        {
            // This will *ONLY* bind to localhost, if you want to bind to all addresses
            // use http://*:8080 to bind to all addresses.
            // See http://msdn.microsoft.com/en-us/library/system.net.httplistener.aspx
            // for more information.
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