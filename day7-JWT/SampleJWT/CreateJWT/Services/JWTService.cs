using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class JwtService
{
    private readonly IConfiguration _config;

    public JwtService(IConfiguration config)
    {
        _config = config;
    }

    public string GenerateToken(string username,string role)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, username), // Claims = data inside the token . Can add more claims based on role
            new Claim(ClaimTypes.Role,role)
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_config["Jwt:Key"])
        );  // JWT signature

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); // defines which key and algorithm to use
        
        // Build the token
        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token); // Convert token to string
    }
}