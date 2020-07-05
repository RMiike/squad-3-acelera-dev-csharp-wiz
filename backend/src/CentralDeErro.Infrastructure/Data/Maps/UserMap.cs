using CentralDeErro.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CentralDeErro.Infrastructure.Data.Maps
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.Property(x => x.FullName)
             .HasColumnName("FullName")
             .HasMaxLength(60)
             .IsRequired();

            builder.Property(x => x.Email)
             .HasColumnName("Email")
             .HasMaxLength(60)
             .IsRequired();

            builder.Property(x => x.CreatedAt)
             .HasColumnName("CreatedAt")
             .IsRequired();

            builder.HasData(
                User.Create("Renato Miike", "rmiike@gmail.com", DateTime.UtcNow, "rmiike@gmail.com")
                );
        }
    }
}
