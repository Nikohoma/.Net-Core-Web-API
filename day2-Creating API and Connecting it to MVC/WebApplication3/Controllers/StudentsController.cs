using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi3.Repositories;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    // Flow : Controller → Repository → DbContext → Database
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _repo;

        public StudentsController(IStudentRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _repo.GetAllAsync();
            return Ok(students);
        }
    }
}
