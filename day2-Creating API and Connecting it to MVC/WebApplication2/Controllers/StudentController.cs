using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("to/[controller]")]
    public class StudentController : ControllerBase
    {
        private static List<Student> _students { get; set; } = new List<Student>()
        {
            new Student (){Id = 1, Name = "A", Grade = 10},
            new Student (){Id = 2, Name = "B", Grade = 8},
            new Student (){Id = 3, Name = "C", Grade = 9}
        };

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            return Ok(_students.AsReadOnly());
        }

        [HttpPost]
        public IActionResult AddStudent(Student s)
        {
            _students.Add(s);
            return Ok(_students);
        }
    }
}
