using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalServer.Hubs;
using SignalServer.Models;
using System.Threading.Tasks;

namespace SignalServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        //OtherHub other;
        IHubContext<MyHub> hubcontext;

        //public HomeController(OtherHub other)
        //{
        //    this.other = other;
        //}

        public HomeController(IHubContext<MyHub> hubContext)
        {
            this.hubcontext = hubContext;
        }

        //public async Task<IActionResult> Index()
        //{
        //    await other.SendMessageAsync("Hello");
        //    return Ok();
        //}

        public async Task<IActionResult> Index()
        {
            await hubcontext.Clients.All.SendAsync("receiveMessage", "Hello World");
            return Ok();
        }
    }
}
