using FluentValidation;
using Categories.Models.FluentValidation;
using CategoriesQuotations.Models.FluentValidation;
using WebApi.Controllers.Categories.Models.FluentValidation;
using WebApi.Controllers.Comments.Models.FluentValidation;
using WebApi.Controllers.Quotations.Models.FluentValidation;
using Common.ModelValidator;
using WebApi.Controllers.Users.Models.FluentValidation;

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
            services.AddValidatorsFromAssemblyContaining<InsertCommentRequestValidator>(ServiceLifetime.Singleton);
            services.AddValidatorsFromAssemblyContaining<InsertQuotationRequestValidator>(ServiceLifetime.Singleton);
            services.AddValidatorsFromAssemblyContaining<RegisterUserRequestValidator>(ServiceLifetime.Singleton);

            // Add ModelValidator
            services.AddAppModelValidator();

            return services;
        }
    }
}
