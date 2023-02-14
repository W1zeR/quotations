using Microsoft.Extensions.DependencyInjection;

namespace Subscriptions
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddSubscriptionService(this IServiceCollection services)
        {
            services.AddSingleton<ISubscriptionService, SubscriptionService>();

            return services;
        }
    }
}
