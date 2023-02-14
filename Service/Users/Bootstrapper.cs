using Microsoft.Extensions.DependencyInjection;

namespace Users
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddUserService(this IServiceCollection services)
        {
            services.AddSingleton<IUserService, UserService>();

            return services;
        }
    }
}
