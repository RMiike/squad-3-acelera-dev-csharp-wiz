using System;
using System.ComponentModel.DataAnnotations;

namespace CentralDeErro.Core.Entities.DTOs
{
    public class LogErroDTO
    {
        [Required]
        [StringLength(60, ErrorMessage = "This field must be between 6 and 60 characters", MinimumLength = 6)]
        public string Title { get;  set; }
        [Required]
        [StringLength(1024, ErrorMessage = "This field must be between 6 and 1024 characters", MinimumLength = 6)]
        public string Details { get;  set; }
        [Required]
        public DateTime CreatedAt { get;  set; }
        [Required]
     
        public int Event { get;  set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid Source")]

        public int EnvironmentId { get;  set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid Source")]
        public int LevelId { get;  set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid Source")]
        public int SourceId { get;  set; }

    }
}
