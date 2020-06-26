using CentralDeErro.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CentralDeErro.Infrastructure.Data.Maps
{
    public class EnvironmentMap : IEntityTypeConfiguration<Environment>
    {
        public void Configure(EntityTypeBuilder<Environment> builder)
        {
            builder.HasData(
                 new Environment(1, "Production"),
                 new Environment(2, "Test"),
                 new Environment(3, "Dev")
                 );
        }
    }
}
