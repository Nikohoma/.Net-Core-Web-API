using Microsoft.EntityFrameworkCore;
using CodeFirst.Data;
using CodeFirst.Models;
using CodeFirst.Repository;
using Microsoft.Identity.Client;

namespace CodeFirst.Services
{
    public class StudentServices
    {
        private readonly IStudentRepository _repo;
        public StudentServices(IStudentRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> CreateNewStudent(Student student)
        {
            return await _repo.CreateStudentAsync(student);
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _repo.GetAllStudentsAsync();
        }

        public async Task<bool> UpdateStudent(int id,Student student)
        {
            return await _repo.UpdateStudentAsync(id,student);
            
        }

        public async Task<Student> Find(int id)
        {
            return await _repo.FindAsync(id);
        }
    }
}
