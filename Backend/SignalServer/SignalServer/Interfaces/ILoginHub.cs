using SignalServer.Models;
using System.Threading.Tasks;

namespace SignalServer.Interfaces
{
    public interface ILoginHub
    {
        Task Login(MyToken token);
        Task Create(bool result);
    }
}
