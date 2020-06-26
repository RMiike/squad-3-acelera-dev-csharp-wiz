﻿using System;
using System.ComponentModel.DataAnnotations;

namespace CentralDeErro.Core.Entities.DTOs
{
    public class LogErroReadDTO
    {
        public LogErroReadDTO(int id, string token, string title, string details, DateTime createdAt, int @event, string environment, string level, string source, bool archived)
        {
            Id = id;
            Token = token;
            Title = title;
            Details = details;
            CreatedAt = createdAt;
            Event = @event;
            Environment = environment;
            Level = level;
            Source = source;
            Archived = archived;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Required field")]
        [MaxLength(450)]
        public string Token { get; set; }
        [Required]
        [StringLength(60, ErrorMessage = "This field must be between 6 and 60 characters", MinimumLength = 6)]
        public string Title { get;  set; }
        [Required]
        [StringLength(1024, ErrorMessage = "This field must be between 6 and 1024 characters", MinimumLength = 6)]
        public string Details { get;  set; }
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Required]
     
        public int Event { get;  set; }
        public string Environment { get;  set; }
        public string Level { get;  set; }
        public string Source { get;  set; }
        public bool Archived { get;  set; }

    }
}