using System;

namespace CentralDeErro.Core.Entities.DTOs
{
    public class ErrorReadDTO
    {
        public ErrorReadDTO(int id, string userId, string fullName, string title, string details, DateTime createdAt, string level, string environment, string address, bool archived)
        {
            Id = id;
            UserId = userId;
            FullName = fullName;
            Title = title;
            Details = details;
            CreatedAt = createdAt;
            Level = level;
            Environment = environment;
            Address = address;
            Archived = archived;
        }
        public int Id { get; private set; }
        public string UserId { get; private set; }
        public string FullName { get; private set; }
        public string Title { get; private set; }
        public string Details { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string Level { get; private set; }
        public string Environment { get; private set; }
        public string Address { get; private set; }
        public bool Archived { get; private set; }
    }
}
