using Microsoft.AspNetCore.Identity;

namespace Context.Entities
{
    public class User : IdentityUser<Guid>
    {
        public virtual ICollection<Subscription> Followers { get; set; } = null!;
        public virtual ICollection<Subscription> Following { get; set; } = null!;
        public virtual ICollection<Quotation> Quotations { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; } = null!;
        public virtual ICollection<CategoryUser> FollowingCategories { get; set; } = null!;
    }
}
