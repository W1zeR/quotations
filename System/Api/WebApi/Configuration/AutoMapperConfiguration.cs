using Categories.Models.AutoMapper;
using Comments.Models.AutoMapper;
using Quotations.Models.AutoMapper;
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
                typeof(InsertCommentModelProfile),
                typeof(InsertQuotationModelProfile),

                // Add AutoMapper to controllers
                typeof(InsertCategoryRequestProfile));

            return services;
        }
    }
}
