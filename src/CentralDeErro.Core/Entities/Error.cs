using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentralDeErro.Core.Entities
{
    // public enum _Environment {Production, Homologation, Development}
    public enum Level {Error, Warning, Debug}
    [Table("Error")]
    public class Error
    {
        public Error()
        {

        }
        public Error(int id, string token, string title,  string details, Level level, DateTime createdAt, int sourceId)
        {
            Id = id;
            Token = token;
            Title = title;
            Details = details;
            CreatedAt = createdAt;
            Level = level;
            SourceId = sourceId;
            Archived = false;
            Deleted = false;
        }
        [Key]
        public int Id { get; private set; }

        [Required(ErrorMessage = "Required field")]
        [MaxLength(450)]
        public string Token { get; private set; }

        [Required(ErrorMessage = "Required field")]
        [StringLength(60, ErrorMessage = "This field must be between 6 and 20 characters", MinimumLength = 6)]
        public string Title { get; private set; }

        [Required(ErrorMessage = "Required field")]
        [MaxLength(1024, ErrorMessage = "This field must have 1024 characters")]
        public string Details { get; private set; }
        public DateTime CreatedAt { get; private set; }
    
        public int SourceId { get; private set; }
        public Source Source { get; private set; }

        public Level Level { get; private set; }

        public bool Archived { get; private set; }
        public bool Deleted { get; private set; }

        public void AddToken(string token)
        {
            Token = token;
        }
        public void MarkAsArchived()
        {
            Archived = true;
        }
        public void MarkAsUnarchived()
        {
            Archived = false;
        }
        public void MarkAsDeleted()
        {
            Archived = true;
        }

    }

}
