using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Motto.MR.Security;
using Motto.MR.Shared.Models;

namespace Motto.MR.Api.Controllers
{
    public class LoginController : Controller
    {
        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] User loginUser)
        {
            var user = Security.Login.ValidateCredentials(loginUser);

            if (user == null || !user.IsAutenticated)
            {
                return Unauthorized("Invalid username/password");
            }

            var token = JwtHandler.GenerateJwtToken(user);
            return Ok(new { token });
        }
    }
}
