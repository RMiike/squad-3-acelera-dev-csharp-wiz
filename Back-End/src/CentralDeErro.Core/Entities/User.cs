using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace CentralDeErro.Core.Entities
{
    public class User : IdentityUser<string>
    {
        private User(string fullName, string email, DateTime createdAt, string userName)
            : base(userName: userName)
        {
            Id = Guid.NewGuid().ToString();
            FullName = fullName;
            Email = email;
            UserName = email;
            CreatedAt = createdAt;
        }

        public string FullName { get; set; }
        public override string Email { get; set; }
        public DateTime CreatedAt { get; private set; }
        public IEnumerable<UserRole> UserRoles { get; private set; }
        public IEnumerable<Error> Errors { get; private set; }

        public static User Create(string fullName, string email, string userName)
        {
            if (String.IsNullOrEmpty(fullName)
                || String.IsNullOrEmpty(email)
                || String.IsNullOrEmpty(userName))
                throw new ArgumentNullException();

            var createdAt = DateTime.UtcNow;
            return new User(fullName, email, createdAt, userName);
        }
    }
}
