using AutoMapper;
using Context.Entities;

namespace Categories.Models.AutoMapper
{
    public class CategoryModelProfile: Profile
    {
        public CategoryModelProfile()
        {
            CreateMap<Category, CategoryModel>();
        }
    }
}
