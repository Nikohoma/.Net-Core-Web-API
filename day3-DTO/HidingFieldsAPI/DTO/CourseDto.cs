using HidingFieldsAPI.Repository;

namespace HidingFieldsAPI.DTO
{
    public class CourseDto
    {
        public string Title { get; set; } = null!;

        public int DurationDays { get; set; }

        public decimal Fee { get; set; }
    }
}
