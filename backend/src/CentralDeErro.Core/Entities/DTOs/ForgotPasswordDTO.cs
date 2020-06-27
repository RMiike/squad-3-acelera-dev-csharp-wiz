using System.ComponentModel.DataAnnotations;

namespace CentralDeErro.Core.Entities.DTOs
{
    public class ForgotPasswordDTO
    {
        [Required(ErrorMessage = "Required field")]
        [StringLength(60, ErrorMessage = "This field must be between 6 and 20 characters", MinimumLength = 6)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid email.")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
