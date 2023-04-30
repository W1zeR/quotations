using AutoMapper;
using Common.Responses.ErrorResponse;
using Microsoft.AspNetCore.Mvc;
using Users;
using WebApi.Controllers.Users.Models;
using Users.Models;

namespace WebApi.Controllers.Users
{
    [ProducesResponseType(typeof(ErrorResponse), 500)]
    [Produces("application/json")]
    [Route("api/users")]
    [ApiController]
    public class UsersController
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UsersController(
            IUserService userService,
            IMapper mapper
        )
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<UserResponse> Insert([FromBody] RegisterUserRequest request)
        {
            var user = await userService.Register(mapper.Map<RegisterUserModel>(request));
            return mapper.Map<UserResponse>(user);
        }
    }
}
