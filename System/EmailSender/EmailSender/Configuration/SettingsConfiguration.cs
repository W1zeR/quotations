using Common.Settings;

namespace EmailSender.Configuration
{
    public static class SettingsConfiguration
    {
        public static IServiceCollection AddAppSettings(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<MailSettings>(configuration.GetRequiredSection(nameof(MailSettings)));
            services.Configure<RabbitMQSettings>(configuration.GetRequiredSection(nameof(RabbitMQSettings)));

            return services;
        }
    }
}
