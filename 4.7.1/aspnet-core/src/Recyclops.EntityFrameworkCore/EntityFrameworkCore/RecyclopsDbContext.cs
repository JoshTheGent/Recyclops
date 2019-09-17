using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Recyclops.Authorization.Roles;
using Recyclops.Authorization.Users;
using Recyclops.Domains.LocationSource;
using Recyclops.Domains.Plastic;
using Recyclops.Domains.PrintableObjects;
using Recyclops.Mappings.LocationSource;
using Recyclops.Mappings.Plastic;
using Recyclops.Mappings.PrintableObjects;
using Recyclops.MultiTenancy;

namespace Recyclops.EntityFrameworkCore
{
    public class RecyclopsDbContext : AbpZeroDbContext<Tenant, Role, User, RecyclopsDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Plastic> Plastics { get; set; }
        public DbSet<PrintableObjects> PrintableObjects { get; set; }
        public DbSet<LocationSource> LocationSources { get; set; }


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

        }
    }
}
