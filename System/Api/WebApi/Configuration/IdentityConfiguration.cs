using Context;
using Context.Entities;
using Microsoft.AspNetCore.Identity;

namespace WebApi.Configuration
{
    public static class IdentityConfiguration
    {
        public static IServiceCollection AddAppIdentity(this IServiceCollection services)
        {
            services
                .AddIdentity<User, IdentityRole<Guid>>(o =>
                {
                    // Password
                    o.Password.RequireDigit = true;
                    o.Password.RequireLowercase = true;
                    o.Password.RequireNonAlphanumeric = true;
                    o.Password.RequireUppercase = true;
                    o.Password.RequiredLength = 6;
                    o.Password.RequiredUniqueChars = 1;

                    // Lockout
                    o.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                    o.Lockout.MaxFailedAccessAttempts = 5;
                    o.Lockout.AllowedForNewUsers = true;

                    // User
                    o.User.AllowedUserNameCharacters =
                        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_";
                    o.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<MainDbContext>()
                .AddUserManager<UserManager<User>>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
