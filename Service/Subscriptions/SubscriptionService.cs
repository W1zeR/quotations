using AutoMapper;
using Common.Exceptions;
using Context;
using Context.Entities;
using Microsoft.EntityFrameworkCore;
using Subscriptions.Models;
using Users.Models;

namespace Subscriptions
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly IDbContextFactory<MainDbContext> contextFactory;
        private readonly IMapper mapper;

        public SubscriptionService(
            IDbContextFactory<MainDbContext> contextFactory,
            IMapper mapper
        )
        {
            this.contextFactory = contextFactory;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<UserModel>> GetFollowersByUserId(Guid userId)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var users = context.Subscriptions
                .Where(s => s.UserId.Equals(userId))
                .Join(context.Users, s => s.FollowerId, u => u.Id, (s, u) => u);
            return (await users.ToListAsync())
                .Select(mapper.Map<UserModel>);
        }

        public async Task<IEnumerable<UserModel>> GetUsersByFollowerId(Guid followerId)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var users = context.Subscriptions
                .Where(s => s.FollowerId.Equals(followerId))
                .Join(context.Users, s => s.UserId, u => u.Id, (s, u) => u);
            return (await users.ToListAsync())
                .Select(mapper.Map<UserModel>);
        }

        public async Task Insert(SubscriptionModel model)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var subscription = mapper.Map<Subscription>(model);
            await context.Subscriptions.AddAsync(subscription);
            await context.SaveChangesAsync();
        }

        public async Task Delete(SubscriptionModel model)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var subscription = await context.Subscriptions.FindAsync(model.UserId, model.FollowerId)
                ?? throw new ServiceException($"Subscription with UserId {model.UserId} " +
                $"and FollowerId {model.FollowerId} wasn't found");
            context.Subscriptions.Remove(subscription);
            await context.SaveChangesAsync();
        }
    }
}
