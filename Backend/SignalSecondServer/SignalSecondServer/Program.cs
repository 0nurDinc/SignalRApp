using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace SignalSecondServer
{
    internal class Program
    {
        static HubConnection connection;

        async static Task Main(string[] args)
        {
            connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/myconnectionevent")
                .Build();

            await connection.StartAsync();

            Console.WriteLine(connection.State);

            connection.On<string>("receiveMessage", message =>
            {
                Console.WriteLine(message);
            });


            connection.On<string>("userJoined", message =>
            {
                Console.WriteLine(message + " attended");
            });

            connection.On<string>("userLeaved", message =>
            {
                Console.WriteLine(message + " left");
            });

            while (true)
            {
                Console.WriteLine("Type the message text to be sent : ");
                await connection.InvokeAsync("SendMessageAsync",Console.ReadLine());
            }
        }

    }
}