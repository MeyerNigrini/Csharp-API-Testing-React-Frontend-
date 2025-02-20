using Application.Services;
using Microsoft.AspNetCore.Mvc;


namespace Presentation.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtTokenService _jwtTokenService;

        public AuthController(JwtTokenService jwtTokenService)
        {
            _jwtTokenService = jwtTokenService;
        }

        [HttpPost("token")]
        public IActionResult GetToken([FromBody] LoginRequest request)
        {
            // Example authentication logic (replace with actual validation)
            if (request.Username == "admin" && request.Password == "admin")
            {
                var token = _jwtTokenService.GenerateToken(request.Username);
                return Ok(new { token });
            }
            return Unauthorized();
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}