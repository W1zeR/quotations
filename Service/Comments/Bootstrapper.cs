using Microsoft.Extensions.DependencyInjection;

namespace Comments
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddCommentService(this IServiceCollection services)
        {
            services.AddSingleton<ICommentService, CommentService>();

            return services;
        }
    }
}
