using CentralDeErro.Core.Entities;
using CentralDeErro.Infrastructure.Data.Maps;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Environment = CentralDeErro.Core.Entities.Environment;

namespace CentralDeErro.Infrastructure.Context
{
    public class CentralDeErrorContext : IdentityDbContext<User, Role, string,
                                                IdentityUserClaim<string>, UserRole, IdentityUserLogin<string>,
                                                IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
       
        public CentralDeErrorContext(DbContextOptions<CentralDeErrorContext> opt) : base(opt) { }

        public DbSet<Error> Errors { get; set; }
        public DbSet<Environment> Environments { get; set; }
        public DbSet<Source> Sources { get; set; }
        public DbSet<Level> Leves { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new UserRoleMap());
            builder.ApplyConfiguration(new EnvironmentMap());
            builder.ApplyConfiguration(new ErrorMap());
            builder.ApplyConfiguration(new LevelMap());
            builder.ApplyConfiguration(new SourceMap());
            builder.ApplyConfiguration(new UserMap());
        }
    }
}
