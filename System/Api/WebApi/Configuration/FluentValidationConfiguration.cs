using Categories.Models.FluentValidation;
using FluentValidation;

namespace WebApi.Configuration
{
    public static class FluentValidationConfiguration
    {
        public static IServiceCollection AddAppFluentValidation(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<InsertCategoryModelValidator>(ServiceLifetime.Singleton);

            return services;
        }
    }
}
