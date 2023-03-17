using Microsoft.OpenApi.Models;

namespace WebApi.Configuration
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection AddAppSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                string xmlFile = "WebApi.xml";
                string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);

                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Quotations WebApi",
                });
            });

            return services;
        }

        public static void UseAppSwagger(this WebApplication app)
        {
            if (!app.Environment.IsDevelopment())
            {
                return;
            }
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });
        }
    }
}
