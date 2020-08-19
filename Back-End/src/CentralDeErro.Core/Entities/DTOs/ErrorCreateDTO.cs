using CentralDeErro.Core.Enums;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace CentralDeErro.Core.Entities.DTOs
{
    public class ErrorCreateDTO : Notifiable, IValidatable
    {
        public int Id { get; }
        public string Title { get; set; }
        public string Details { get; set; }
        public int SourceId { get; set; }
        public Level Level { get;  set; }
        public string UserId { get; private set; }

        public void AddUserId(string userId)
        {
            if (String.IsNullOrEmpty(userId))
                throw new ArgumentNullException("Insert a valid user id");

            UserId = userId;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasMaxLen(Title, 60, "Title", "This field should have no more than 60 chars.")
                .HasMinLen(Title, 3, "Title", "This field should have at least 3 chars.")
                .HasMaxLen(Details, 1024, "Details", "This field should have no more than 1024 chars.")
                .HasMinLen(Details, 6, "Details", "This field should have at least 6 chars.")
                .IsBetween(SourceId, 1,100, "SourceId", "The value must be a valid id")
                .IsBetween(Level.GetHashCode(), 0, (Level.GetNames(typeof(Level)).Length - 1), "Level", $"The value must be between 0 and 2"));
        }
    }
}
