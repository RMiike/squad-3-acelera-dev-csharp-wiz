using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentralDeErro.Core.Entities
{
    [Table("Error")]
    public class Error
    {
        public Error(int id, string token, string title, string details, DateTime createdAt, int @event, int environmentId, int sourceId, int levelId)
        {
            Id = id;
            Token = token;
            Title = title;
            Details = details;
            CreatedAt = createdAt;
            Event = @event;
            EnvironmentId = environmentId;
            SourceId = sourceId;
            LevelId = levelId;
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
        public int Event { get; private  set; }


        [Range(1, int.MaxValue, ErrorMessage = "Invalid Environment")]
        public int EnvironmentId { get; private set; }
        public Environment Environment { get; private set; }

        [Range(1, int.MaxValue, ErrorMessage = "Invalid Source")]
        public int SourceId { get; private set; }
        public Source Source { get; private  set; }

        [Range(1, int.MaxValue, ErrorMessage = "Invalid Level")]

        public int LevelId { get; private set; }
        public Level Level { get; private set; }
        //public bool Archived { get; private set; }

    //arquivado / deletado?
    }

}
