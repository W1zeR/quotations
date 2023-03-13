using Context;
using Microsoft.EntityFrameworkCore;

namespace CategoriesQuotations.Models.FluentValidation
{
    public class InsertCategoryQuotationModelValidator : GenericCategoryQuotationModelValidator<InsertCategoryQuotationModel>
    {
        public InsertCategoryQuotationModelValidator(IDbContextFactory<MainDbContext> contextFactory) : base(contextFactory)
        {
        }
    }
}
