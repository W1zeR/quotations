using AutoMapper;
using Context.Entities;

namespace Categories.Models.AutoMapper
{
    public class AddCategoryModelProfile: Profile
    {
        public AddCategoryModelProfile()
        {
            CreateMap<AddCategoryModel, Category>();
        }
    }
}
