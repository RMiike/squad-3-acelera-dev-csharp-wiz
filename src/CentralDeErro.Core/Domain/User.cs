using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CentralDeErro.Core.Domain
{
    public class User : IdentityUser
    {
        public List<UserRoles> UserRoles { get; set; }
        //TODO 39
    }
}
