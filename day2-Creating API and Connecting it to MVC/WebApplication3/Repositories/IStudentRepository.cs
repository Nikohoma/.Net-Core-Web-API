using WebApplication3.Models;

// IRepository because Loose Coupling, No tightly bind with db, multiple service can connect to it, can handle multiple request
namespace WebApi3.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync();
        Task<Student?> GetByIdAsync(int id);
        Task<Student> AddAsync(Student student);
        Task UpdateAsync(Student student);
        Task DeleteAsync(int id);
    }
}
