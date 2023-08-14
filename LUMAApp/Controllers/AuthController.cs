using LUMAApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LUMAApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            Console.WriteLine(configuration.ToString());
            _configuration = configuration;
        }

        private string GenerateJwtToken(string username, string role, string dept)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role),
                new Claim(ClaimTypes.Upn, dept)
                // Add more claims as needed (e.g., roles, permissions)
            };

            Console.WriteLine(_configuration["Jwt:KEY"]);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            Console.WriteLine(credentials.ToString());
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginRequest model)
        {
            if (model.EmployeeId == "AD1011" && model.Password == "admin@123")
            {
                var token = GenerateJwtToken(model.EmployeeId, "Admin", "HR");
                return StatusCode(200, new { token });
            }
            return StatusCode(403, new MessageResponse()
            {
                Message = "Unauthorised"
            });
        }

        [HttpGet("user")]
        [Authorize]
        public IActionResult GetUser()
        {
            var name = User.FindFirst(ClaimTypes.Name)?.Value;
            var role = User.FindFirst(ClaimTypes.Role)?.Value;
            var dept = User.FindFirst(ClaimTypes.Upn)?.Value;

            return StatusCode(200, new
            {
                name,
                role,
                dept
            });
        }

        [HttpGet("logout")]
        [Authorize]
        public IActionResult Logout()
        {
            try
            {
                var logoutResponse = new MessageResponse() { Message = "Successful Login" };
                return StatusCode(200, logoutResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(403, new MessageResponse()
                {
                    Message = "Unauthorised"
                });
            }
        }
    }
}
