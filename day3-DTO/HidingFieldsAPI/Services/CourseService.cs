using HidingFieldsAPI.Repository;
using Microsoft.AspNetCore.Http.Features;
using HidingFieldsAPI.Models;
using HidingFieldsAPI.DTO;
using System.Web.Http.Controllers;


namespace HidingFieldsAPI.Services
{
    public class CourseService
    {
        private readonly ICourseRepository _repo;

        public CourseService(ICourseRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<CourseDto>> GetAllAsync()
        {
            var courses = await _repo.GetAllCoursesAsync();
            return courses.Select(c => new CourseDto() { Title = c.Title, DurationDays = c.DurationDays , Fee = c.Fee }).ToList();
        }
    }
}
