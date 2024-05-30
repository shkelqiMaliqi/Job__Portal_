using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Job__Portal_
{
    public class TokenAuth
    {
        public interface ITokenAuth
        {
            string GenerateToken(string userId);
        }

        public class TokenAuth : ITokenAuth
        {
            private readonly string _secret;

            public TokenAuth(IConfiguration configuration)
            {
                _secret = configuration.GetValue<string>("Jwt:Secret");
            }

            public string GenerateToken(string userId)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] { new Claim("id", userId) }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
        }
    }
}
