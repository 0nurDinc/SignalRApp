using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;

namespace SignalServer.Models
{
    public class TokenHandler
    {
        readonly IConfiguration configuration;

        public TokenHandler(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public MyToken CreateAccessToken(int duration)
        {
            MyToken token = new MyToken();
            
            SymmetricSecurityKey securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jwt:SecurityKey"]));
            
            SigningCredentials signingCredentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
            
            token.Expiration = DateTime.Now.AddMinutes(duration);
            
            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer: configuration["jst:Issuer"],
                audience: configuration["jwt:Audience"],
                expires: token.Expiration,
                notBefore: DateTime.Now,
                signingCredentials: signingCredentials);

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            token.AccessToken = tokenHandler.WriteToken(securityToken);
            token.RefreshToken = CreateRefreshToken();
            return token;

        }

        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using RandomNumberGenerator random = RandomNumberGenerator.Create();
            random.GetBytes(number);
            return Convert.ToBase64String(number);
        }
    }
}
