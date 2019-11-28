using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Recyclops.Authorization.Roles;
using Recyclops.Authorization.Users;
using Recyclops.Domains.LocationSource;
using Recyclops.Domains.Order;
using Recyclops.Domains.Plastic;
using Recyclops.Domains.PlasticOrder;
using Recyclops.Domains.PlasticSpool;
using Recyclops.Domains.PrintableObject;
using Recyclops.Domains.PrintableOrder;
using Recyclops.Mappings.LocationSource;
using Recyclops.Mappings.Order;
using Recyclops.Mappings.Plastic;
using Recyclops.Mappings.PlasticOrder;
using Recyclops.Mappings.PlasticSpool;
using Recyclops.Mappings.PrintableObjects;
using Recyclops.Mappings.PrintableOrder;
using Recyclops.MultiTenancy;

namespace Recyclops.EntityFrameworkCore
{
    public class RecyclopsDbContext : AbpZeroDbContext<Tenant, Role, User, RecyclopsDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Plastic> Plastics { get; set; }
        public DbSet<PrintableObject> PrintableObjects { get; set; }
        public DbSet<LocationSource> LocationSources { get; set; }
        public DbSet<PlasticSpool> PlasticSpools { get; set; }
        public DbSet<PlasticOrder> PlasticOrders { get; set; }
        public DbSet<PrintableOrder>PrintableOrders { get; set; }
        public DbSet<Order> Orders { get; set; }


    public RecyclopsDbContext(DbContextOptions<RecyclopsDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PlasticConfiguration());
            modelBuilder.ApplyConfiguration(new PrintableObjectsConfiguration());
            modelBuilder.ApplyConfiguration(new LocationSourceConfiguration());
            modelBuilder.ApplyConfiguration(new PlasticSpoolConfiguration());
            modelBuilder.ApplyConfiguration(new PlasticOrderConfiguration());
            modelBuilder.ApplyConfiguration(new PrintableOrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());

        }
    }
}
