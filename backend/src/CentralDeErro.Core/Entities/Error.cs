using CentralDeErro.Core.Enums;
using System;

namespace CentralDeErro.Core.Entities
{
    public class Error
    {
        protected Error() { }
        private Error(int id, string token, string title, string details, Level level, DateTime createdAt, int sourceId, bool archived, bool deleted)
        {
            Id = id;
            Token = token;
            Title = title;
            Details = details;
            CreatedAt = createdAt;
            Level = level;
            SourceId = sourceId;
            Archived = archived;
            Deleted = deleted;
        }
        public int Id { get; }
        public string Token { get; }
        public string Title { get; }
        public string Details { get; }
        public DateTime CreatedAt { get; }
        public int SourceId { get; }
        public Source Source { get; }
        public Level Level { get; }
        public bool Archived { get; private set; }
        public bool Deleted { get; private set; }

        public static Error Create(int id, string token, string title, string details, Level level, int sourceId)
        {
            if (String.IsNullOrEmpty(token)
                || String.IsNullOrEmpty(title)
                || String.IsNullOrEmpty(details))
            {
                throw new ArgumentNullException();
            }
            var createdAt = DateTime.UtcNow;
            var archived = false;
            var deleted = false;
            return new Error(id, token, title, details, level, createdAt, sourceId, archived, deleted);
        }

        public void Archive()
        {
            if (Id == 0)
                throw new ArgumentNullException("Invalid id.");
            if (Archived == true)
                throw new InvalidOperationException("Error is already archived.");

            Archived = true;
        }
        public void Unarchive()
        {

            if (Archived == false)
                throw new InvalidOperationException("Error is already unarchived.");

            Archived = false;
        }
        public void Delete()
        {
            if (Deleted == true)
                throw new InvalidOperationException("Error is already deleted.");

            Deleted = true;
        }

    }

}
