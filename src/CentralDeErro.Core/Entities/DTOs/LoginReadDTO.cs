using System.ComponentModel.DataAnnotations;

namespace CentralDeErro.Core.Entities.DTOs
{
    public class LoginReadDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Token { get; private set; }

        public void AddToken(string token)
        {
            Token = token;
        }
    }
}
