using Microsoft.Extensions.DependencyInjection;

namespace Quotations
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddQuotationService(this IServiceCollection services)
        {
            services.AddSingleton<IQuotationService, QuotationService>();

            return services;
        }
    }
}
