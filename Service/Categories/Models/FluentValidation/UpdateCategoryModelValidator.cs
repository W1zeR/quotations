using Context;
using Microsoft.EntityFrameworkCore;

namespace Categories.Models.FluentValidation
{
    public class UpdateCategoryModelValidator : GenericCategoryModelValidator<UpdateCategoryModel>
    {
        public UpdateCategoryModelValidator(IDbContextFactory<MainDbContext> contextFactory) : base(contextFactory) { }
    }
}
