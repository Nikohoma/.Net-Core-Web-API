using CodeFirst.Data;
using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _context;

        public StudentRepository(StudentDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateStudentAsync(Student student)
        {
            if (student != null)
            {
                await _context.Students.AddAsync(student);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            var students = await _context.Students.ToListAsync();
            if (students != null) { return students; }
            return new List<Student>();
        }

        public async Task<bool> UpdateStudentAsync(int id,Student student)
        {
            var found = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
            if(found!= null)
            {
                found.Name = student.Name;
                found.Grade = student.Grade;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Student> FindAsync(int id)
        {
            if (id == 0 || id < 0) { return null; }
            return await _context.Students.FirstOrDefaultAsync(s=>s.Id==id) ?? new Student() { };
        }
    }
}
