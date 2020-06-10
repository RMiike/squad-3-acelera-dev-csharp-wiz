using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CentralDeErro.Core.Domain
{
    public class Role : IdentityRole
    {
        public List<UserRoles> UserRoles { get; set; }

    }
}
