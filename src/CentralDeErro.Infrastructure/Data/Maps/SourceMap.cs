using CentralDeErro.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CentralDeErro.Infrastructure.Data.Maps
{
    public class SourceMap : IEntityTypeConfiguration<Source>
    {
        public void Configure(EntityTypeBuilder<Source> builder)
        {
            builder.HasData(
                 new Source(1, "Front-End"),
                  new Source(2, "Back-End")
                  );
        }
    }
}
