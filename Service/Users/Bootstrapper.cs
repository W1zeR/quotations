using Microsoft.Extensions.DependencyInjection;

namespace Users
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddUserService(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
