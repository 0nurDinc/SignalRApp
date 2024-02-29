using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SignalServer.Context;
using SignalServer.Interfaces;
using SignalServer.Models;
using System.Threading.Tasks;

namespace SignalServer.Hubs
{
    public class MyLoginHub:Hub<ILoginHub>
    {
        readonly IConfiguration configuration;
        readonly UserDB context;

        public MyLoginHub(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.context = new UserDB();
        }

        public async Task CreateUser(string username, string password)
        {
            await context.Users.AddAsync(new User { UserName = username, Password = password });

            await Clients.Caller.Create(await context.SaveChangesAsync()>0);
        }

        public async Task UserLogin(string username,string password)
        {
            User user = await context.Users.FirstOrDefaultAsync(u => u.UserName == username && u.Password == password);

            MyToken token = null;
            if (user != null)
            {
                TokenHandler tokenHandler = new TokenHandler(configuration);
                token = tokenHandler.CreateAccessToken(5);
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenEndDate = token.Expiration.AddMinutes(3);
                await context.SaveChangesAsync();
            }

            await Clients.Caller.Login(user != null ? token : null);
        }
    }
}
