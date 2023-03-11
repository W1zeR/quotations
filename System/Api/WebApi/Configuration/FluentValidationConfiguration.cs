using FluentValidation;
using Categories.Models.FluentValidation;
using Comments.Models.FluentValidation;
using Quotations.Models.FluentValidation;
using WebApi.Controllers.Categories.Models.FluentValidation;

namespace WebApi.Configuration
{
    public static class FluentValidationConfiguration
    {
        public static IServiceCollection AddAppFluentValidation(this IServiceCollection services)
        {
            // Add FluentValidation to services
            services.AddValidatorsFromAssemblyContaining<InsertCategoryModelValidator>(ServiceLifetime.Singleton);
            services.AddValidatorsFromAssemblyContaining<InsertCommentModelValidator>(ServiceLifetime.Singleton);
            services.AddValidatorsFromAssemblyContaining<InsertQuotationModelValidator>(ServiceLifetime.Singleton);

            // Add FluentValidation to controllers
            services.AddValidatorsFromAssemblyContaining<InsertCategoryRequestValidator>(ServiceLifetime.Singleton);

            return services;
        }
    }
}
