using System.ComponentModel.DataAnnotations;

namespace CentralDeErro.Core.Dto
{
    public class SignInDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
