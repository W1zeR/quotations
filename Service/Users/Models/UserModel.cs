namespace Users.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = null!;
        public string? Email { get; set; }
    }
}
