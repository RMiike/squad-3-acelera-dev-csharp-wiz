using CentralDeErro.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeErro.Infrastructure.Context
{
    public class CentralDeErrorContext : IdentityDbContext<User, Role, string,
                                                IdentityUserClaim<string>, UserRoles, IdentityUserLogin<string>,
                                                IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public CentralDeErrorContext(DbContextOptions<CentralDeErrorContext> opt) : base(opt) { }

        public DbSet<LogError> LogError { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserRoles>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();
                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            builder.Entity<LogError>(logError =>
            {
                logError.ToTable("LogErros");
                logError.HasKey(le => le.Id);

                logError.Property(le => le.UserToken)
                        .HasColumnName("usertoken")
                        .HasColumnType("varchar(max)")
                        .IsRequired();

                logError.Property(le => le.Title)
                      .HasColumnName("title")
                      .HasColumnType("varchar(450)")
                      .IsRequired();

                logError.Property(le => le.Details)
                     .HasColumnName("details")
                     .HasColumnType("varchar(450)")
                     .IsRequired();

               
                      

            });

        //public Source Source { get; set; }    
        //public DateTime Moment { get; set; }
        //public Level Level { get; set; }
        //public int Event { get; set; }

        //public Environment Environment { get; set; }

    }
    }
}
