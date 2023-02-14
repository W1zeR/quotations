using Categories;
using Comments;
using Quotations;
using Subscriptions;
using Users;

namespace WebApi.Configuration
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services
                .AddCategoryService()
                .AddCommentService()
                .AddQuotationService()
                .AddSubscriptionService()
                .AddUserService()
                ;

            return services;
        }
    }
}
