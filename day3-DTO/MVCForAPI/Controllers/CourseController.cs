using MVCForAPI.Services;
using MVCForAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc;

namespace MVCForAPI.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApiClientService _service;

        public CourseController(ApiClientService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _service.GetListAsync<CourseViewModel>("Course");
            return View(result);
        }
    }
}
