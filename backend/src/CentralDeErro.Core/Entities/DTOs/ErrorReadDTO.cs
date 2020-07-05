using System;

namespace CentralDeErro.Core.Entities.DTOs
{
    public class ErrorReadDTO
    {
        public ErrorReadDTO(int id, string token, string title, string details, DateTime createdAt, string level, string environment, string adress, bool archived)
        {
            Id = id;
            Token = token;
            Title = title;
            Details = details;
            CreatedAt = createdAt;
            Level = level;
            Environment = environment;
            Adress = adress;
            Archived = archived;
        }
        public int Id { get; private set; }
        public string Token { get; private set; }
        public string Title { get; private set; }
        public string Details { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string Level { get; private set; }
        public string Environment { get; private set; }
        public string Adress { get; private set; }
        public bool Archived { get; private set; }
    }
}
