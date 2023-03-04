using AutoMapper;
using Context.Entities;

namespace Categories.Models.AutoMapper
{
    public class InsertCategoryModelProfile: Profile
    {
        public InsertCategoryModelProfile()
        {
            CreateMap<InsertCategoryModel, Category>();
        }
    }
}
