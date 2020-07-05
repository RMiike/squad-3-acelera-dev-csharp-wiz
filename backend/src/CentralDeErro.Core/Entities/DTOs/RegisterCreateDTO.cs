using Flunt.Notifications;
using Flunt.Validations;

namespace CentralDeErro.Core.Entities.DTOs
{
    public class RegisterCreateDTO : Notifiable, IValidatable
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public void Validate()
        {
            AddNotifications(
                 new Contract()
                     .Requires()
                     .HasMaxLen(FullName, 100, "FullName", "FullName should have no more than 100 chars")
                     .HasMinLen(FullName, 3, "FullName", "FullName should have at least 3 chars")
                     .IsEmail(Email, "E-mail", "Invalid email.")
                     .HasMaxLen(Password, 100, "Password", "Password should have no more than 100 chars")
                     .HasMinLen(Password, 8, "Password", "Password should have at least 8 chars")
                     .HasMaxLen(ConfirmPassword, 100, "ConfirmPassword", "Password should have no more than 100 chars")
                     .HasMinLen(ConfirmPassword, 8, "ConfirmPassword", "Password should have at least 6 chars")
                     .AreEquals(ConfirmPassword, Password, "ConfirmPassword", "The password and confirmation password do not match."));

        }
    }
}
