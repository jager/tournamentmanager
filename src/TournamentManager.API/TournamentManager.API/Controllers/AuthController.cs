using Microsoft.AspNetCore.Mvc;
using TournamentManager.API.Requests.Authentication;
using Webbers.Authentication;

namespace TournamentManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;

        public AuthController(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }
        [HttpPost("signin")]
        public IActionResult SignIn(User user)
        {
            var token = _jwtAuthenticationManager.Authenticate(user.UserName, user.Password);
            if (token == null)
                return Unauthorized();

            return Ok(new { @token = token });
        }
    }
}
