using System.Threading.Tasks;

namespace SignalServer.Interfaces
{
    public interface IMyHub
    {
        Task ReceiveMessage(string message);
    }
}
