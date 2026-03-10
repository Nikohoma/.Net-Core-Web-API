using HidingFieldsAPI.Models;

namespace HidingFieldsAPI.Repository
{
    public interface IStudentRepository
    {
        Task<List<Students>> GetAllAsync();
        Task AddAsync(Students student); // 6. Create a method that is implemented by studentRepository
    }
}
