using CentralDeErro.Core.Entities;
using CentralDeErro.Core.Enums;
using Microsoft.EntityFrameworkCore;
using System;

namespace CentralDeErro.Infrastructure.Data.Maps
{
    public class ErrorMap : IEntityTypeConfiguration<Error>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Error> builder)
        {
            builder.ToTable("Error");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
              .HasColumnName("Id")
              .IsRequired();

            builder.Property(x => x.Token)
            .HasColumnName("Token")
            .HasMaxLength(450)
            .IsRequired();

            builder.Property(x => x.Title)
            .HasColumnName("Title")
            .HasMaxLength(60)
            .IsRequired();

            builder.Property(x => x.Details)
            .HasColumnName("Details")
            .HasMaxLength(1024)
            .IsRequired();

            builder.Property(x => x.CreatedAt)
            .HasColumnName("CreatedAt")
            .IsRequired();

            builder.Property(x => x.SourceId)
            .HasColumnName("SourceId")
            .IsRequired();

            builder.Property(x => x.Level)
                .HasConversion(x => x.ToString(), x => Enum.Parse<Level>(x))
            .HasColumnName("Level")
            .IsRequired();


            builder.Property(x => x.Archived)
            .HasColumnName("Archived")
            .IsRequired();


            builder.Property(x => x.Deleted)
            .HasColumnName("Deleted")
            .IsRequired();


            builder.HasOne(x => x.Source)
            .WithMany(x => x.Errors)
            .HasForeignKey(x => x.SourceId);

            #region add data
            var title = "Description Project File Suppression State Line";
            var detail = @"Error CS7036  There is no argument given that corresponds to the required formal parameter 'id' of 'Error.Error(int, string, string, string, DateTime, int, int, int, int)'	EziLog.Infrastructure D:\source\repos\EziLog\src\EziLog.Infrastructure\Data\Maps\ErrorMap.cs Active  15";
            var token = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJkYzgyMTI2NDhhIiwidW5pcXVlX25hbWUiOiJtaWlrZTIyMjMiLCJuYmYiOjE1OTE5MDE1OTMsImV4cCI6MTU5MTk4Nzk5MywiaWF0IjoxNTkxOTAxNTkzfQ.Tn-dAuEsod3HM1nQuqoFQ8HppCvls3cKW8ps_8sIbMp2OxGjwivzqsen_nvA4hu49Wt_fjWGBXkCS5IHulJJAQ";
            var errorData = Error.Create(1, token, title, detail, Level.Debug, 1);
            #endregion

            builder.HasData(errorData);
        }
    }
}
