using EmailSender.Controllers.Mails.Models.AutoMapper;

namespace EmailSender.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection AddAppAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(
                // Add AutoMapper to controllers
                typeof(MailRequestProfile)
            );

            return services;
        }
    }
}
