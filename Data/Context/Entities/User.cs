using Microsoft.AspNetCore.Identity;

namespace Context.Entities
{
    public class User : IdentityUser<Guid>
    {
        public virtual ICollection<Subscription>? Followers { get; set; }
        public virtual ICollection<Subscription>? Following { get; set; }
        public virtual ICollection<Quotation>? Quotations { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
        public virtual ICollection<CategoryUser>? FollowingCategories { get; set; }
    }
}
