using CentralDeErro.Core.Entities;
using CentralDeErro.Infrastructure.Data.Maps;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CentralDeErro.Infrastructure.Context
{
    public class CentralDeErrorContext : IdentityDbContext<User, Role, string,
                                                IdentityUserClaim<string>, UserRole, IdentityUserLogin<string>,
                                                IdentityRoleClaim<string>, IdentityUserToken<string>>
    {

        public CentralDeErrorContext(DbContextOptions<CentralDeErrorContext> opt) : base(opt) { }

        public DbSet<Error> Errors { get; set; }
        public DbSet<Source> Sources { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(UserRoleMap).Assembly);
        }
    }
}
