using Categories.Models.AutoMapper;
using CategoriesQuotations.Models.AutoMapper;
using CategoriesUsers.Models.AutoMapper;
using Comments.Models.AutoMapper;
using Quotations.Models.AutoMapper;
using Subscriptions.Models.AutoMapper;
using Users.Models.AutoMapper;
using WebApi.Controllers.Categories.Models.AutoMapper;

namespace WebApi.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection AddAppAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(
                // Add AutoMapper to services
                typeof(InsertCategoryModelProfile),
                typeof(CategoryQuotationModelProfile),
                typeof(CategoryUserModelProfile),
                typeof(InsertCommentModelProfile),
                typeof(InsertQuotationModelProfile),
                typeof(SubscriptionModelProfile),
                typeof(UserModelProfile),

                // Add AutoMapper to controllers
                typeof(InsertCategoryRequestProfile));

            return services;
        }
    }
}
