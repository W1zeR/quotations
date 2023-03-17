using WebApi.Middlewares;

namespace WebApi.Configuration
{
    public static class MiddlewaresConfiguration
    {
        public static void UseAppMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionsMiddleware>();
        }
    }
}
