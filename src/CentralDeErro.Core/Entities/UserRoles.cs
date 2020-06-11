
using Microsoft.AspNetCore.Identity;

namespace CentralDeErro.Core.Entities
{
    public class UserRoles : IdentityUserRole<string>
    {
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
