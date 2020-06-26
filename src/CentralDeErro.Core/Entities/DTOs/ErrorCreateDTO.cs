using System;
using System.ComponentModel.DataAnnotations;

namespace CentralDeErro.Core.Entities.DTOs
{
    public class ErrorCreateDTO
    {
        [Required]
        [StringLength(60, ErrorMessage = "This field must be between 6 and 60 characters", MinimumLength = 6)]
        public string Title { get; set; }
        [Required]
        [StringLength(1024, ErrorMessage = "This field must be between 6 and 1024 characters", MinimumLength = 6)]
        public string Details { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Required]

        public int SourceId { get; set; }
        [Required]
        public int Level { get; set; }

    }
}
