using FluentValidation;
using Categories.Models.FluentValidation;
using CategoriesQuotations.Models.FluentValidation;
using WebApi.Controllers.Categories.Models.FluentValidation;

namespace WebApi.Configuration
{
    public static class FluentValidationConfiguration
    {
        public static IServiceCollection AddAppFluentValidation(this IServiceCollection services)
        {
            // Add FluentValidation to services
            services.AddValidatorsFromAssemblyContaining<InsertCategoryModelValidator>(ServiceLifetime.Singleton);
            services.AddValidatorsFromAssemblyContaining<InsertCategoryQuotationModelValidator>(ServiceLifetime.Singleton);

            // Add FluentValidation to controllers
            services.AddValidatorsFromAssemblyContaining<InsertCategoryRequestValidator>(ServiceLifetime.Singleton);

            return services;
        }
    }
}
