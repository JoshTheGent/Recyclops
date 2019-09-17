using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Recyclops.Mappings.LocationSource
{
    public class LocationSourceConfiguration : IEntityTypeConfiguration<Domains.LocationSource.LocationSource>
    {
        public void Configure(EntityTypeBuilder<Domains.LocationSource.LocationSource> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("LocationSource");
            builder.HasMany(x => x.Plastics).WithOne(x => x.LocationSource).HasForeignKey(x => x.LocationSourceId);
        }
    }
}
