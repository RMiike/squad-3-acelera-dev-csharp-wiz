using Flunt.Notifications;
using Flunt.Validations;

namespace CentralDeErro.Core.Entities.DTOs
{
    public class ChangePasswordDTO : Notifiable, IValidatable
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMaxLen(OldPassword, 100, "OldPassword", "Password should have no more than 100 chars")
                    .HasMinLen(OldPassword, 8, "OldPassword", "Password should have at least 6 chars")
                    .HasMaxLen(NewPassword, 100, "NewPassword", "Password should have no more than 100 chars")
                    .HasMinLen(NewPassword, 8, "NewPassword", "Password should have at least 6 chars")
                    .HasMaxLen(ConfirmPassword, 100, "ConfirmPassword", "Password should have no more than 100 chars")
                    .HasMinLen(ConfirmPassword, 8, "ConfirmPassword", "Password should have at least 6 chars")
                    .AreEquals(ConfirmPassword, NewPassword, "ConfirmPassword", "The password and confirmation password do not match.")) ; 
        }
    }
}
