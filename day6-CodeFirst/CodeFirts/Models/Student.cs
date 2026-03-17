using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required, StringLength(15), MinLength(3)]
        public string Name { get; set; }
        [Range(1,12)]
        public int Grade { get; set; }
    }
}
