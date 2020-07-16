using CentralDeErro.Core.Entities;
using CentralDeErro.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Environment = CentralDeErro.Core.Enums.Environment;

namespace CentralDeErro.Infrastructure.Data.Maps
{
    public class SourceMap : IEntityTypeConfiguration<Source>
    {
        public void Configure(EntityTypeBuilder<Source> builder)
        {
            builder.ToTable("Source");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
            .HasColumnName("Id")
            .IsRequired();

            builder.Property(x => x.Address)
            .HasColumnName("Address")
             .HasMaxLength(60)
            .HasColumnType("varchar(60)")
            .IsRequired();

            builder.Property(x => x.Environment)
            .HasConversion(x => x.ToString(), x => Enum.Parse<Environment>(x))
            .HasColumnName("Environment")
             .HasMaxLength(50)
            .HasColumnType("varchar(50)")
            .IsRequired();

            builder.Property(x => x.Deleted)
          .HasColumnName("Deleted")
          .IsRequired();

            builder.HasData(
                 Source.Create(1, "Front-End", Environment.Development),
                 Source.Create(2, "Front-End", Environment.Homologation),
                 Source.Create(3, "Front-End", Environment.Production),
                 Source.Create(4, "Back-End", Environment.Development),
                 Source.Create(5, "Back-End", Environment.Homologation),
                 Source.Create(6, "Back-End", Environment.Production)
                  );

        }
    }
}
