using CentralDeErro.Core.Entities;
using CentralDeErro.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            .IsRequired();

            builder.Property(x => x.Environment)
            .HasColumnName("Environment")
            .IsRequired();

            builder.HasData(
                 Source.Create(1, "Front-End", _Environment.Development),
                 Source.Create(2, "Front-End", _Environment.Homologation),
                 Source.Create(3, "Front-End", _Environment.Production),
                 Source.Create(4, "Back-End", _Environment.Development),
                 Source.Create(5, "Back-End", _Environment.Homologation),
                 Source.Create(6, "Back-End", _Environment.Production)
                  );
        }
    }
}
