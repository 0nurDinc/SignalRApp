using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalServer.Hubs
{
    public class MyHub:Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync(method: "receiveMessage", message);
        }
    }
}
