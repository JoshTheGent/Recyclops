using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Recyclops.Mappings.PlasticSpool
{
    public class PlasticSpoolConfiguration : IEntityTypeConfiguration<Domains.PlasticSpool.PlasticSpool>
    {
        public void Configure(EntityTypeBuilder<Domains.PlasticSpool.PlasticSpool> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("PlasticSpool");
            builder.HasOne(x => x.Plastic).WithMany(x => x.PlasticSpools).HasForeignKey(x => x.PlasticId);
            builder.HasMany(x => x.PrintableObjects).WithOne(x => x.PlasticSpool).HasForeignKey(x => x.PlasticSpoolId);
            builder.HasMany(x => x.PlasticOrders).WithOne(x => x.PlasticSpool).HasForeignKey(x => x.PlasticSpoolId);


        }
    }
}
