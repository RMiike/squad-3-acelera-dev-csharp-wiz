using Flunt.Notifications;
using Flunt.Validations;

namespace CentralDeErro.Core.Entities.DTOs
{
    public class ForgotPasswordDTO : Notifiable, IValidatable
    {
        public string Email { get; set; }
        public void Validate()
        {
            AddNotifications(
               new Contract()
               .Requires()
               .IsEmail(Email, "Email", "Invalid email."));
        }
    }
}
