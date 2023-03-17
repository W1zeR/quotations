using Microsoft.Extensions.DependencyInjection;

namespace Common.ModelValidator
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddAppModelValidator(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IModelValidator<>), typeof(ModelValidator<>));

            return services;
        }
    }
}
