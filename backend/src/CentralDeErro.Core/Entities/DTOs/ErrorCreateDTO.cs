using CentralDeErro.Core.Enums;
using Flunt.Notifications;
using Flunt.Validations;

namespace CentralDeErro.Core.Entities.DTOs
{
    public class ErrorCreateDTO : Notifiable, IValidatable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public int SourceId { get; set; }
        public Level Level { get; private set; }
        public string Token { get; private set; }

        public void AddToken(string token)
        {
            Token = token;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasMaxLen(Title, 60, "Title", "This field should have no more than 60 chars.")
                .HasMinLen(Title, 6, "Title", "This field should have at least 6 chars.")
                .HasMaxLen(Details, 1024, "Details", "This field should have no more than 1024 chars.")
                .HasMinLen(Details, 6, "Details", "This field should have at least 6 chars.")
                .IsBetween(SourceId, 1, 6,"SourceId","The value must be between 1 and 6")
                .IsBetween(Level.GetHashCode(), 0, 2, "Level", "The value must be between 0 and 2"));
        }
    }
}
