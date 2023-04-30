using Microsoft.Extensions.DependencyInjection;

namespace Mails
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddMailService(this IServiceCollection services)
        {
            services.AddTransient<IMailService, MailService>();

            return services;
        }
    }
}
