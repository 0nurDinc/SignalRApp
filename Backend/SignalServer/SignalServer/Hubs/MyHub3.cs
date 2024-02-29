using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SignalServer.Hubs
{
    public class MyHub3:Hub
    {
        static List<string> allclient = new List<string>();
        public async Task SendMessageAsync(string message)
        {
            await Clients.All.SendAsync("receiveMessage",message);
        }

        public override async Task OnConnectedAsync()
        {
            allclient.Add(Context.ConnectionId);
            await Clients.All.SendAsync("userJoined", $"{Context.ConnectionId}");
            await Clients.All.SendAsync("clients", allclient);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            allclient.Remove(Context.ConnectionId);
            await Clients.All.SendAsync("userLeaved", $"{Context.ConnectionId}");
            await Clients.All.SendAsync("clients", allclient);
        }
    }
}
