using HidingFieldsAPI.Data;
using HidingFieldsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HidingFieldsAPI.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentPortalDbContext _context;

        public StudentRepository(StudentPortalDbContext context)
        {
            _context = context;
        }

        // Create a method in IStudentRepository first
        public async Task AddAsync(Students student)   //7. Add student directly to dbContext
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

        }

        public async Task<List<Students>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }
        
    }
}
