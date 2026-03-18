using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly JwtService _jwtService;

    public AuthController(JwtService jwtService)
    {
        _jwtService = jwtService;
    }

    [HttpPost("login")]
    public IActionResult Login(string username, string password)
    {
        // Dummy validation (replace with DB check)
        if (username == "admin" && password == "password")
        {
            var token = _jwtService.GenerateToken(username,"Admin");
            return Ok(new { token });
        }
        if (username == "Nikhil" && password == "nik123")
        {
            var token = _jwtService.GenerateToken(username, "User");
            return Ok(new { token });
        }


        return Unauthorized();
    }
}