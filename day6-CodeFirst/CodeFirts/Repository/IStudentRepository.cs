using CodeFirst.Data;
using CodeFirst.Models;

namespace CodeFirst.Repository
{
    public interface IStudentRepository
    {
        Task<bool> CreateStudentAsync(Student student);
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<bool> UpdateStudentAsync(int id,Student student);

        Task<Student> FindAsync(int id);
    }
}
