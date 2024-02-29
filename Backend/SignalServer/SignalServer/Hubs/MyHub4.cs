using Microsoft.AspNetCore.SignalR;
using SignalServer.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SignalServer.Hubs
{
    public class MyHub4:Hub<IMyHub>
    {
        //public async Task SendMessage(string message)
        //{
        //    await Clients.All.SendAsync("receiveMessage", message);
        //}

        public async Task SendMessage(string message)
        {
            await Clients.All.ReceiveMessage(message);
        }
        
    }
}
