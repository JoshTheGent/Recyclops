using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Recyclops.Mappings.PrintableObjects
{
    public class PrintableObjectsConfiguration : IEntityTypeConfiguration<Domains.PrintableObject.PrintableObject>
    {
        public void Configure(EntityTypeBuilder<Domains.PrintableObject.PrintableObject> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("PrintableObjects");
            builder.HasOne(x => x.PlasticSpool).WithMany(x => x.PrintableObjects).HasForeignKey(x => x.PlasticSpoolId);
            builder.HasMany(x => x.PrintableOrders).WithOne(x => x.PrintableObject).HasForeignKey(x => x.PrintableObjectId);
        }
    }
}
