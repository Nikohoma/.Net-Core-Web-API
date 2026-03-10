using HidingFieldsAPI.Models;
namespace HidingFieldsAPI.Repository
{
    public interface ICourseRepository
    {
        Task<List<Courses>> GetAllCoursesAsync();
    }
}
