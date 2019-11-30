using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Recyclops.Mappings.PlasticOrder
{
    public class PlasticOrderConfiguration : IEntityTypeConfiguration<Domains.PlasticOrder.PlasticOrder>
    {
        public void Configure(EntityTypeBuilder<Domains.PlasticOrder.PlasticOrder> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("PlasticOrder");
            builder.HasOne(x => x.PlasticSpool).WithMany(x => x.PlasticOrders).HasForeignKey(x => x.PlasticSpoolId);
            builder.HasOne(x => x.Order).WithMany(x => x.PlasticOrders).HasForeignKey(x => x.OrderId);


        }
    }
}
