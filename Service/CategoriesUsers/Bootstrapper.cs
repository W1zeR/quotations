using Microsoft.Extensions.DependencyInjection;

namespace CategoriesUsers
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddCategoryUserService(this IServiceCollection services)
        {
            services.AddSingleton<ICategoryUserService, CategoryUserService>();

            return services;
        }
    }
}
