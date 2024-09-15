using ImplementationJWT.Models;
using ImplementationJWT.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ImplementationJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
       
    public class tokensController : ControllerBase
    {
        private IConfiguration _configuration;
        private IGenerateJwtToken _generateJwtToken;

        public tokensController(IConfiguration configuration, IGenerateJwtToken generateJwtToken)
        {
            _configuration = configuration;
            _generateJwtToken = generateJwtToken;
        }

        // GET: api/<AuthenticationController>
        [HttpPost("login")]
        public IActionResult Login([FromBody] User login)
        {
            if (login.Name == "token" && login.Password == "password")
            {
                var token = _generateJwtToken.CreateJwtToken(login.Name);
                return Ok(new { token });
            }

            return Unauthorized();
        }

    }
    
}
