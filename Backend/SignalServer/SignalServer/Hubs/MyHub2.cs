using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalServer.Hubs
{
    public class MyHub2:Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("logsendmessage", message);
        }
    }
}
