using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Recyclops.Mappings.Order
{
    public class OrderConfiguration : IEntityTypeConfiguration<Domains.Order.Order>
    {
        public void Configure(EntityTypeBuilder<Domains.Order.Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Order");
            builder.HasMany(x => x.PlasticOrders).WithOne(x => x.Order).HasForeignKey(x => x.OrderId);
            builder.HasMany(x => x.PrintableOrders).WithOne(x => x.Order).HasForeignKey(x => x.OrderId);
            builder.HasOne(x => x.Client).WithMany(x => x.Orders).HasForeignKey(x => x.ClientId);


        }
    }
}
