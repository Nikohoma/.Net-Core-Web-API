using HidingFieldsAPI.Services;
using Microsoft.AspNetCore.Mvc;
using HidingFieldsAPI.Services;
namespace HidingFieldsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : Controller
    {
        private readonly CourseService _service;
        public CourseController(CourseService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> AllCourses()
        {
            var courses = await _service.GetAllAsync();
            return Ok(courses);
        }

    }
}
