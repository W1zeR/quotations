using AutoMapper;
using Categories.Models;

namespace WebApi.Controllers.Categories.Models.AutoMapper
{
    public class UpdateCategoryRequestProfile : Profile
    {
        public UpdateCategoryRequestProfile()
        {
            CreateMap<UpdateCategoryRequest, UpdateCategoryModel>();
        }
    }
}
