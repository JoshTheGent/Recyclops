using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Recyclops.Mappings.PrintableOrder
{
    public class PrintableOrderConfiguration : IEntityTypeConfiguration<Domains.PrintableOrder.PrintableOrder>
    {
        public void Configure(EntityTypeBuilder<Domains.PrintableOrder.PrintableOrder> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("PrintableOrder");
            builder.HasOne(x => x.PrintableObject).WithMany(x => x.PrintableOrders).HasForeignKey(x => x.PrintableObjectId);
            builder.HasOne(x => x.Order).WithMany(x => x.PrintableOrders).HasForeignKey(x => x.OrderId);


        }
    }
}
