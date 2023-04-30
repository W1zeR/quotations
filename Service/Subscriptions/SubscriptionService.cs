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

        public async Task<IEnumerable<SubscriptionModel>> GetAll(int offset = 0, int limit = 10)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var subscriptions = context.Subscriptions
                .AsQueryable()
                .Skip(Math.Max(offset, 0))
                .Take(Math.Max(0, Math.Min(limit, 1000)));
            return (await subscriptions.ToListAsync())
                .Select(mapper.Map<SubscriptionModel>);
        }

        public async Task<SubscriptionModel> GetById(int id)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var subscription = await context.Subscriptions.FindAsync(id);
            return subscription == null
                ? throw new ServiceException($"Subscription with id {id} wasn't found")
                : mapper.Map<SubscriptionModel>(subscription);
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

        public async Task Insert(InsertSubscriptionModel model)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var subscription = mapper.Map<Subscription>(model);
            await context.Subscriptions.AddAsync(subscription);
            await context.SaveChangesAsync();
        }

        public async Task Update(int id, UpdateSubscriptionModel model)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var subscription = await context.Subscriptions.FindAsync(id)
                ?? throw new ServiceException($"Subscription with id {id} wasn't found");
            subscription = mapper.Map(model, subscription);
            context.Subscriptions.Update(subscription);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var subscription = await context.Subscriptions.FindAsync(id)
                ?? throw new ServiceException($"Subscription with id {id} wasn't found");
            context.Subscriptions.Remove(subscription);
            await context.SaveChangesAsync();
        }
    }
}
