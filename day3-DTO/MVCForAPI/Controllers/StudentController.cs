using Microsoft.AspNetCore.Mvc;
using MVCForAPI.Models;
using MVCForAPI.Services;

namespace MVCForAPI.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApiClientService _api;

        public StudentController(ApiClientService api)
        {
            _api = api;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _api.GetListAsync<StudentViewModel>("Student") ?? new List<StudentViewModel>()) ;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentViewModel student)
        {
            if (!ModelState.IsValid)
                return View(student);

            await _api.PostAsync("Student", student);

            return RedirectToAction("Index");
        }
    }
}
