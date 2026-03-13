using Microsoft.AspNetCore.Mvc;
using Service1.Services;

namespace Service1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : Controller
    {
        [HttpGet]
        public IActionResult GetCatalogs()
        {
            var result = CatalogServices.GetAllCatalogs();
            return Ok(result);
        }
    }
}
