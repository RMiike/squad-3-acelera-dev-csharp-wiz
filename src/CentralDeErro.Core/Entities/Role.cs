using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CentralDeErro.Core.Entities
{
    public class Role : IdentityRole<string>
    {
        public List<UserRoles> UserRoles { get; set; }

    }
}
