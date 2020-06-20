using CentralDeErro.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CentralDeErro.Infrastructure.Data.Maps
{
    public class LevelMap : IEntityTypeConfiguration<Level>
    {
        public void Configure(EntityTypeBuilder<Level> builder)
        {
            builder.HasData(
                 new Level(1, "Error"),
                 new Level(2, "Warning"),
                 new Level(3, "Debug")
                 );
        }
    }
}
