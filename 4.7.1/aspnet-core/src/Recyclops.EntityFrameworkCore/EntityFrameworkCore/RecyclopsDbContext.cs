using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Recyclops.Authorization.Roles;
using Recyclops.Authorization.Users;
using Recyclops.MultiTenancy;

namespace Recyclops.EntityFrameworkCore
{
    public class RecyclopsDbContext : AbpZeroDbContext<Tenant, Role, User, RecyclopsDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public RecyclopsDbContext(DbContextOptions<RecyclopsDbContext> options)
            : base(options)
        {
        }
    }
}
