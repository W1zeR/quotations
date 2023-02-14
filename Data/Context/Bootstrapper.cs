using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Context
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddAppDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextFactory<MainDbContext>(o => o.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
