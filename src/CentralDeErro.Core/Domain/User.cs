using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace CentralDeErro.Core.Domain
{
    public class User : IdentityUser<string>
    {
        public User(string userName, string email)
        {
            Id = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);
            UserName = userName;
            Email = email;
        }
        public List<UserRoles> UserRoles { get; set; }
        //TODO 39
    }
}
