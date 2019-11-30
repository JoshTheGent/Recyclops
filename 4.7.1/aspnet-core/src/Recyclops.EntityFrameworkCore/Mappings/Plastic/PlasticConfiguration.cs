using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Recyclops.Mappings.Plastic
{
    public class PlasticConfiguration : IEntityTypeConfiguration<Domains.Plastic.Plastic>
    {
        public void Configure(EntityTypeBuilder<Domains.Plastic.Plastic> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Plastic");
            builder.HasOne(x => x.LocationSource).WithMany(x => x.Plastics).HasForeignKey(x => x.LocationSourceId);
            builder.HasMany(x => x.PlasticSpools).WithOne(x => x.Plastic).HasForeignKey(x => x.PlasticId);

        }
    }
}
