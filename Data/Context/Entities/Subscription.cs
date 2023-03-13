namespace Context.Entities
{
    public class Subscription
    {
        public int Id { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; } = null!;

        public Guid FollowerId { get; set; }
        public virtual User Follower { get; set; } = null!;
    }
}
