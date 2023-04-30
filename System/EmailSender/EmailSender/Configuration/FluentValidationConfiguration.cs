using EmailSender.Controllers.Mails.Models.FluentValidation;
using FluentValidation;
using Common.ModelValidator;

namespace EmailSender.Configuration
{
    public static class FluentValidationConfiguration
    {
        public static IServiceCollection AddAppFluentValidation(this IServiceCollection services)
        {
            // Add FluentValidation to controllers
            services.AddValidatorsFromAssemblyContaining<MailRequestValidator>(ServiceLifetime.Singleton);

            // Add ModelValidator
            services.AddAppModelValidator();

            return services;
        }
    }
}
