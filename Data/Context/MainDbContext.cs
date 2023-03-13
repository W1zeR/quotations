using Context.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Context
{
    public class MainDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryQuotation> CategoriesQuotations { get; set; }
        public DbSet<CategoryUser> CategoriesUsers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Quotation> Quotations { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CategoryQuotation>()
                .HasIndex(cq => new { cq.CategoryId, cq.QuotationId }).IsUnique();

            modelBuilder.Entity<CategoryUser>()
                .HasIndex(cu => new { cu.CategoryId, cu.UserId }).IsUnique();

            modelBuilder.Entity<Subscription>()
                .HasIndex(s => new { s.UserId, s.FollowerId }).IsUnique();

            modelBuilder.Entity<Subscription>()
                .HasOne(s => s.User)
                .WithMany(u => u.Followers)
                .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<Subscription>()
                .HasOne(s => s.Follower)
                .WithMany(u => u.Following)
                .HasForeignKey(s => s.FollowerId);
        }
    }
}
