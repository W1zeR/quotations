using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Context.Factories
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MainDbContext>
    {
        public MainDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            DbContextOptions<MainDbContext> options = new DbContextOptionsBuilder<MainDbContext>()
                .UseLazyLoadingProxies()
                .UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
                .Options;

            var dbContextFactory = new DbContextFactory(options);
            return dbContextFactory.Create();
        }
    }
}
