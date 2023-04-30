namespace WebApi.Controllers.Users.Models
{
    public class RegisterUserRequest
    {
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
