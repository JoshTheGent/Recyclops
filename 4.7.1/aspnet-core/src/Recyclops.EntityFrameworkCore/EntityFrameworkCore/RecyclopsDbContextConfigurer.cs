using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Recyclops.EntityFrameworkCore
{
    public static class RecyclopsDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<RecyclopsDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<RecyclopsDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
