using HidingFieldsAPI.DTO;
using HidingFieldsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HidingFieldsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _service;

        public StudentController(StudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _service.GetAllStudentsAsync();
            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(StudentCreateDto student)  // 1. Taking inputs of Dto columns
        {
            await _service.CreateNewStudent(student);   // 2. Sending it to method in service
            return Ok();
        }
    }
}
