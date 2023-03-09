using Microsoft.Extensions.DependencyInjection;

namespace CategoriesQuotations
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddCategoryQuotationService(this IServiceCollection services)
        {
            services.AddSingleton<ICategoryQuotationService, CategoryQuotationService>();

            return services;
        }
    }
}
