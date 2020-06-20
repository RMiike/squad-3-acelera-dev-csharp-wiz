using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CentralDeErro.Core.Entities
{
    public class Role : IdentityRole<string>
    {
        public List<UserRole> UserRoles { get; set; }
    }
}
