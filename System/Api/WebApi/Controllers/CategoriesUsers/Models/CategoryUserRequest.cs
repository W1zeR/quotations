namespace WebApi.Controllers.CategoriesUsers.Models
{
    public class CategoryUserRequest
    {
        public int CategoryId { get; set; }
        public Guid UserId { get; set; }
    }
}
