namespace WebApi.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection AddAppAutoMapper(this IServiceCollection services)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            services.AddAutoMapper(assemblies);

            return services;
        }
    }
}
