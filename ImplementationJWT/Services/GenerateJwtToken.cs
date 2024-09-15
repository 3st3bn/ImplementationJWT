using ImplementationJWT.Models;
using ImplementationJWT.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ImplementationJWT.Services
{
    public class GenerateJwtToken : IGenerateJwtToken
    {
        private IConfiguration _configuration;
        public GenerateJwtToken(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string CreateJwtToken(string username)
        {
            var key = Encoding.ASCII.GetBytes(_configuration["jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, username)
            }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["jwt:Issuer"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
