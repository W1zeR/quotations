using Categories;
using CategoriesQuotations;
using CategoriesUsers;
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
                .AddCategoryQuotationService()
                .AddCategoryUserService()
                .AddCommentService()
                .AddQuotationService()
                .AddSubscriptionService()
                .AddUserService()
                ;

            return services;
        }
    }
}
