using Context;
using Microsoft.EntityFrameworkCore;

namespace CategoriesQuotations.Models.FluentValidation
{
    public class UpdateCategoryQuotationModelValidator : GenericCategoryQuotationModelValidator<UpdateCategoryQuotationModel>
    {
        public UpdateCategoryQuotationModelValidator(IDbContextFactory<MainDbContext> contextFactory) : base(contextFactory)
        {
        }
    }
}
