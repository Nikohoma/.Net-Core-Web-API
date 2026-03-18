using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RolesWithJWT.Controllers
{
    [Authorize]                         // any authenticated user
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        [Authorize(Roles = "Admin")]    // only admin role
        public IActionResult AdminPanel() => View();

        [Authorize(Roles = "User,Admin")]    // only user and admin role
        public IActionResult UserPanel() => View();
    }
}