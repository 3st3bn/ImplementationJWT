using ImplementationJWT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ImplementationJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
       
    public class AuthenticationController : ControllerBase
    {
        private IConfiguration _configuration;

        public AuthenticationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/<AuthenticationController>
        [HttpPost("login")]
        public IActionResult Login([FromBody] User login)
        {
            if (login.Name == "token" && login.Password == "password")
            {
                var token = GenerateJwtToken(login.Name);
                return Ok(new { token });
            }

            return Unauthorized();
        }

        private string GenerateJwtToken(string username)
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
