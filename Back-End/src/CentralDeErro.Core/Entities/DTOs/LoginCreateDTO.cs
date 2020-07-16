using Flunt.Notifications;
using Flunt.Validations;

namespace CentralDeErro.Core.Entities.DTOs
{
    public class LoginCreateDTO : Notifiable, IValidatable
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsEmail(Email, "E-mail", "Invalid email.")
                .HasMaxLen(Password, 60, "Password", "This field should have no more than 60 chars.")
                .HasMinLen(Password, 8, "Password", "This field should have at least 8 chars."));
        }
    }
}
