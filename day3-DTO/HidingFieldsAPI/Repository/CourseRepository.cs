using HidingFieldsAPI.Data;
using HidingFieldsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HidingFieldsAPI.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly StudentPortalDbContext _context;

        public CourseRepository(StudentPortalDbContext context)
        {
            _context = context;
        }

        public async Task<List<Courses>> GetAllCoursesAsync()
        {
            return await _context.Courses.ToListAsync();
        }
    }
}
