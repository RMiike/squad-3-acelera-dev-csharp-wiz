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
                 new Source(1, "Front-End", _Environment.Development),
                 new Source(2, "Front-End", _Environment.Homologation),
                 new Source(3, "Front-End", _Environment.Production),
                 new Source(4, "Back-End", _Environment.Development),
                 new Source(5, "Back-End", _Environment.Homologation),
                  new Source(6, "Back-End", _Environment.Production)
                  );
        }
    }
}
