using System.ComponentModel.DataAnnotations;

namespace HidingFieldsAPI.DTO
{
    public class StudentCreateDto
    {
        [Required]
        public string FullName { get; set; } = null!;

        [Required,EmailAddress, StringLength(180)]
        public string Email { get; set; } = null!;
    }
}
