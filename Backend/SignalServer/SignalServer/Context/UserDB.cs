using Microsoft.EntityFrameworkCore;
using SignalServer.Models;

namespace SignalServer.Context
{
    public class UserDB:DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserDB()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=UserDB; Trusted_Connection = True;");
        }
    }
}
