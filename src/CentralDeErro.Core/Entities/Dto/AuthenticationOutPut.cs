using System.ComponentModel.DataAnnotations;

namespace CentralDeErro.Core.Entities.Dto
{
    public class AuthenticationOutPut
       
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Token { get; set; }
    }
}
