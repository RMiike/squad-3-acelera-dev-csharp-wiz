using CentralDeErro.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Environment = CentralDeErro.Core.Entities.Environment;

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

            //TODO criar configuração em camada separada    
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

                logError.HasOne(le => le.Environment)
                       .WithMany(le => le.LogsError)
                       .HasForeignKey(le => le.EnvironmentId);

                logError.HasOne(le => le.Level)
                       .WithMany(le => le.LogsError)
                       .HasForeignKey(le => le.LevelId);

                logError.HasOne(le => le.Source)
                     .WithMany(le => le.LogsError)
                     .HasForeignKey(le => le.SourceId);

                logError.HasData(
                    new LogError()
                    {
                        Id = 1,
                        UserToken = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJkYzgyMTI2NDhhIiwidW5pcXVlX25hbWUiOiJtaWlrZTIyMjMiLCJuYmYiOjE1OTE5MDE1OTMsImV4cCI6MTU5MTk4Nzk5MywiaWF0IjoxNTkxOTAxNTkzfQ.Tn-dAuEsod3HM1nQuqoFQ8HppCvls3cKW8ps_8sIbMp2OxGjwivzqsen_nvA4hu49Wt_fjWGBXkCS5IHulJJAQ",
                        Title = "acceleration.Detail: <not_found>",
                        Details = "File '/go/pkg/mod/github.com/sirupsen/logurs@v1.1.0'",
                        Moment = DateTime.Now,
                        Event = 1000,
                        EnvironmentId = 1,
                        LevelId = 1,
                        SourceId = 1
                    });
            });

            builder.Entity<Environment>(environment =>
            {
                environment.ToTable("environment");

                environment.HasKey(e => e.Id);

                environment.Property(e => e.Description)
                       .HasColumnName("description")
                       .HasColumnType("varchar(450)")
                       .IsRequired();

                environment.HasData(
                 new Environment(1, "Production"),
                 new Environment(2, "Test"),
                 new Environment(3, "Dev")
                 );
            });
            builder.Entity<Level>(level =>
            {
                level.ToTable("level");

                level.HasKey(l => l.Id);

                level.Property(l => l.Description)
                       .HasColumnName("description")
                       .HasColumnType("varchar(450)")
                       .IsRequired();

                level.HasData(
                 new Level(1, "Error"),
                 new Level(2, "Warning"),
                 new Level(3, "Debug")
                 );
            });
            builder.Entity<Source>(source =>
            {
                source.ToTable("source");

                source.HasKey(s => s.Id);

                source.Property(s => s.Description)
                       .HasColumnName("description")
                       .HasColumnType("varchar(450)")
                       .IsRequired();
                source.HasData(
                 new Source(1, "Front-End"),
                  new Source(2, "Back-End")
                            );
            });
        }
    }
}
