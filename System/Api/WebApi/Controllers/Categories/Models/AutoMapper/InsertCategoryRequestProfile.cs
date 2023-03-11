using AutoMapper;
using Categories.Models;

namespace WebApi.Controllers.Categories.Models.AutoMapper
{
    public class InsertCategoryRequestProfile : Profile
    {
        public InsertCategoryRequestProfile()
        {
            CreateMap<InsertCategoryRequest, InsertCategoryModel>();
        }
    }
}
