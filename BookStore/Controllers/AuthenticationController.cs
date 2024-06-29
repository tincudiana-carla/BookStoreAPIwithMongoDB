using BookStore.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : Controller
    {
        private IConfiguration _configuration;
        

            public AuthenticationController(IConfiguration config)
            {
                _configuration = config;
            }

            [HttpPost("login")]
            public IActionResult Login([FromBody] LoginDomain userLogin)
            {
                var user = Authenticate(userLogin);

                if (user != null)
                {
                    var token = Generate(user);
                    return Ok(token);
                }

                return NotFound("User not found");
            }

            private string Generate(LoginDomain user)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Username),
                };

                var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                  _configuration["Jwt:Audience"],
                  claims,
                  expires: DateTime.Now.AddMinutes(15),
                  signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }

            private LoginDomain Authenticate(LoginDomain userLogin)
            {
                var users = new List<LoginDomain>
                {
                    new LoginDomain { Username = "user1", Password = "password1" },
                    new LoginDomain { Username = "user2", Password = "password2" },
                    new LoginDomain { Username = "admin", Password = "adminpassword" }
                };

                var currentUser = users.FirstOrDefault(o =>
                    o.Username.Equals(userLogin.Username, StringComparison.OrdinalIgnoreCase) &&
                    o.Password == userLogin.Password);

                if (currentUser != null)
                {
                    return currentUser;
                }

                return null;
            }
        }


    
}
