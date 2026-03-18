using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CreateJWT.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Get Token
            var token = HttpContext.Session.GetString("JWT");
            if (token is null) { return RedirectToAction("Index", "Login"); }

            // Decode token
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);

            // Extract roles
            var roles = jwt.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();

            // Send to view
            ViewBag.Roles = roles;
            return View();
        }
    }
}
