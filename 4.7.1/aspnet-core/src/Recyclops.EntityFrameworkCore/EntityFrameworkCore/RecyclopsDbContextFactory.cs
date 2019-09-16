using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Recyclops.Configuration;
using Recyclops.Web;

namespace Recyclops.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class RecyclopsDbContextFactory : IDesignTimeDbContextFactory<RecyclopsDbContext>
    {
        public RecyclopsDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<RecyclopsDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            RecyclopsDbContextConfigurer.Configure(builder, configuration.GetConnectionString(RecyclopsConsts.ConnectionStringName));

            return new RecyclopsDbContext(builder.Options);
        }
    }
}
