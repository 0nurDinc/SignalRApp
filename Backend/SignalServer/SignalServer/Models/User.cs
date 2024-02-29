using System;

namespace SignalServer.Models
{
    public class User
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenEndDate { get; set; }
    }
}
