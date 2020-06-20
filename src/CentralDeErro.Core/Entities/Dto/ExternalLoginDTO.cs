using System.ComponentModel.DataAnnotations;

namespace CentralDeErro.Core.Entities.Dto
{
    public class ExternalLoginDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
