using System.ComponentModel.DataAnnotations;

namespace HidingFieldsAPI.DTO
{
    public class StudentDto
    {
        [Required, StringLength(25)]
        public string FullName { get; set; } = null!;
        [Required, EmailAddress]
        public string Email { get; set; } = null!;

        public string Status { get; set; } = null!;


    }
}
