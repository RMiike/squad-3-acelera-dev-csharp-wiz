using CentralDeErro.Core.Enums;
using Flunt.Notifications;
using Flunt.Validations;

namespace CentralDeErro.Core.Entities.DTOs
{
    public class SourceCreateDTO : Notifiable, IValidatable
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public _Environment Environment { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasMaxLen(Address,1024,"Address", "This field should have no more than 1024 chars.")
                .HasMinLen(Address, 6, "Address", "This field should have at least 6 chars.")
                .IsBetween(Environment.GetHashCode(), 0, (_Environment.GetNames(typeof(_Environment)).Length - 1), "Environment", "The value must be between 0 and 2")
                );
        }
    }
}
