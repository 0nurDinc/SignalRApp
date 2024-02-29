using System;

namespace SignalServer.Models
{
    public class MyToken
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
        public string RefreshToken { get; set; }
    }
}
