using LUMAApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.MSIdentity.Shared;

namespace LUMAApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest model)
        {
            if (model.Email == "admin@wellsfargo.com" && model.Password == "admin@123")
            {
                var loginResponse = new LoginResponse() { Message = "Successful Login" };
                return StatusCode(200, loginResponse);
            }
            return StatusCode(403, new LoginResponse()
            {
                Message = "Unauthorised"
            });
        }

    }
}
