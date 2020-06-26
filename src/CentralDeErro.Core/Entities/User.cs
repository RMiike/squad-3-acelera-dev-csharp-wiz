using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CentralDeErro.Core.Entities
{
    public class User : IdentityUser<string>
    {
        public User(string fullName, string email, DateTime createdAt, string userName)
            : base(userName: userName)
        {
            Id = Guid.NewGuid().ToString();
            FullName = fullName;
            Email = email;
            UserName = email;
            CreatedAt = createdAt;
        }
        [Required(ErrorMessage = "Required field")]
        [StringLength(60, ErrorMessage = "This field must be between 6 and 20 characters", MinimumLength = 6)]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Required field")]
        [StringLength(60, ErrorMessage = "This field must be between 6 and 20 characters", MinimumLength = 6)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid email.")]
        public override string Email { get; set; }
        public DateTime CreatedAt { get; private set; }
        public IEnumerable<UserRole> UserRoles { get; private set; }

        //TODO 39
    }
}
