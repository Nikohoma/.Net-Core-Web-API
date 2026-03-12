namespace MVCForAPI.Models
{
    public class CourseViewModel
    {
        public int CourseId { get; set; }
        public string Title { get; set; } = null!;

        public int DurationDays { get; set; }

        public decimal Fee { get; set; }
    }
}
