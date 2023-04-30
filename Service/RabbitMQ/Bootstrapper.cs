using Microsoft.Extensions.DependencyInjection;

namespace RabbitMQ
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddRabbitMQ(this IServiceCollection services)
        {
            services.AddSingleton<IRabbitMQ, RabbitMQ>();

            return services;
        }
    }
}
