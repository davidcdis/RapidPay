using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RapidPay.API.Dtos;
using RapidPay.API.Filters;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace RapidPay.API.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        ///  Default credentials: User: user, Password: pass
        /// </summary>
        [HttpPost]
        [Route("/auth/get-token")]
        public IActionResult GetToken(GetTokenRequest request)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            if (request.UserName.StartsWith("user") && request.Password.StartsWith("pass"))
            {
                var secretKey = Encoding.ASCII.GetBytes(_configuration["SecretKey"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(secretKey), 
                        SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(tokenString);
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
