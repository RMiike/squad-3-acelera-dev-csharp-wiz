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
        public int Id { get; set; }

        [Required(ErrorMessage = "Required field")]
        [MaxLength(450)]
        public string Token { get; set; }

        [Required(ErrorMessage = "Required field")]
        [StringLength(60, ErrorMessage = "This field must be between 6 and 20 characters", MinimumLength = 6)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Required field")]
        [MaxLength(1024, ErrorMessage = "This field must have 1024 characters")]
        public string Details { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Event { get; set; }


        [Range(1, int.MaxValue, ErrorMessage = "Invalid Environment")]
        public int EnvironmentId { get; set; }
        public Environment Environment { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Invalid Source")]
        public int SourceId { get; set; }
        public Source Source { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Invalid Level")]

        public int LevelId { get; set; }
        public Level Level { get; set; }
    //arquivado / deletado?
    }

}
