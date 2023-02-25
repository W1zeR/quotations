using AutoMapper;
using Context.Entities;

namespace Categories.Models.AutoMapper
{
    public class UpdateCategoryModelProfile: Profile
    {
        public UpdateCategoryModelProfile()
        {
            CreateMap<UpdateCategoryModel, Category>();
        }
    }
}
