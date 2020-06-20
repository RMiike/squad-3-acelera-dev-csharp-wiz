using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CentralDeErro.Core.Entities
{
    public class User : IdentityUser<string>
    {
        public User(string email, DateTime createdAt, string userName)
            : base(userName: userName)
        {
            Id = Guid.NewGuid().ToString();
            Email = email;
            UserName = email;
            CreatedAt = createdAt;
        }
        
        [Required(ErrorMessage = "Required field")]
        [StringLength(60, ErrorMessage = "This field must be between 6 and 20 characters", MinimumLength = 6)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid email.")]
        public override string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public IEnumerable<UserRole> UserRoles { get; set; }

        //TODO 39
    }
}
