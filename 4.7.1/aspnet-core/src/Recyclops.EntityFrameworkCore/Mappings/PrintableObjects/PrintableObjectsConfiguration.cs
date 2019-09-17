using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Recyclops.Mappings.PrintableObjects
{
    public class PrintableObjectsConfiguration : IEntityTypeConfiguration<Domains.PrintableObjects.PrintableObjects>
    {
        public void Configure(EntityTypeBuilder<Domains.PrintableObjects.PrintableObjects> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("PrintableObjects");
        }
    }
}
