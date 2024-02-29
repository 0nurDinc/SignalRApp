using Microsoft.AspNetCore.SignalR;
using SignalServer.Hubs;
using System.Threading.Tasks;

namespace SignalServer.Models
{
    public class OtherHub
    {
        readonly IHubContext<MyHub> hubcontext;

        public OtherHub(IHubContext<MyHub> hubcontext)
        {
            this.hubcontext = hubcontext;
        }

        public void SendMessage(string message)
        {
            this.hubcontext.Clients.All.SendAsync("receiveMessage", message);
        }
    }
}
