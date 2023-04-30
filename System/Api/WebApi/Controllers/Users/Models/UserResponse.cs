﻿namespace WebApi.Controllers.Users.Models
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = null!;
        public string? Email { get; set; }
    }
}
