using System;
using Microsoft.AspNet.SignalR.Client;
using SignalRPoc.Shared;

namespace SignalRPoc.Client
{
    internal static class Program
    {
        private static void Main()
        {
            var connection = new HubConnection(Settings.SignalREndpoint);
            var myHubProxy = connection.CreateHubProxy("MyHub");
            connection.Start().Wait();

            Console.WriteLine($"Listening on {Settings.SignalREndpoint}");
            myHubProxy.On("sendMessage", message =>
            {
                Console.WriteLine(message);
            });

            myHubProxy.Invoke("Register", "Koen").Wait();
            Console.ReadLine();
        }
    }
}


