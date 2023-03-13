using Context;
using Microsoft.EntityFrameworkCore;

namespace Categories.Models.FluentValidation
{
    public class InsertCategoryModelValidator : GenericCategoryModelValidator<InsertCategoryModel>
    {
        public InsertCategoryModelValidator(IDbContextFactory<MainDbContext> contextFactory) : base(contextFactory) { }
    }
}