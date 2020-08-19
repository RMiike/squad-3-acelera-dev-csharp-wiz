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


            builder.Property(x => x.Title)
            .HasColumnName("Title")
             .HasMaxLength(60)
             .HasColumnType("varchar(60)")
            .IsRequired();

            builder.Property(x => x.Details)
            .HasColumnName("Details")
             .HasMaxLength(1024)
             .HasColumnType("varchar(1024)")
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
             .HasMaxLength(50)
            .HasColumnType("varchar(50)")
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

                builder.Property(x => x.UserId)
            .HasColumnName("UserId")
               .HasMaxLength(450)
             .HasColumnType("varchar(450)")
            .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.Errors)
                .HasForeignKey(x => x.UserId);

            //#region add data
            //var title = "Description Project File Suppression State Line";
            //var detail = @"Error CS7036  There is no argument given that corresponds to the required formal parameter 'id' of 'Error.Error(int, string, string, string, DateTime, int, int, int, int)'	EziLog.Infrastructure D:\source\repos\EziLog\src\EziLog.Infrastructure\Data\Maps\ErrorMap.cs Active  15";
            //var token = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiI1YjlmYTNhYi0zMjBiLTRjNzUtOTMyMi0zOGYzM2FlM2VmZGMiLCJlbWFpbCI6InJtaWlrZS45MEBnbWFpbC5jb20iLCJ1bmlxdWVfbmFtZSI6IlJlbmF0byBBbHZlcyIsIm5iZiI6MTU5NTU0NjEzMCwiZXhwIjoxNTk1NjMyNTMwLCJpYXQiOjE1OTU1NDYxMzB9.K5RhT2V3OGpwD0Tif6L5gb6BwqwD__edIxHb6a1PqZgW8EK9fJlux621L0-bWdTxaJqI5yuJ92SS39hEK2Yt4w";
            //var errorData = Error.Create(1, token, title, detail, Level.Debug, 1);
            //#endregion

            //builder.HasData(errorData);
        }
    }
}
