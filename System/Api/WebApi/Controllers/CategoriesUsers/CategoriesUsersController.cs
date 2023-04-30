using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CategoriesUsers;
using WebApi.Controllers.CategoriesUsers.Models;
using CategoriesUsers.Models;
using Common.Responses.ErrorResponse;

namespace WebApi.Controllers.CategoriesUsers
{
    [ProducesResponseType(typeof(ErrorResponse), 500)]
    [Produces("application/json")]
    [Route("api/categories-users")]
    [ApiController]
    public class CategoriesUsersController : ControllerBase
    {
        private readonly ICategoryUserService categoryUserService;
        private readonly IMapper mapper;

        public CategoriesUsersController(
            ICategoryUserService categoryUserService,
            IMapper mapper
        )
        {
            this.categoryUserService = categoryUserService;
            this.mapper = mapper;
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(IEnumerable<CategoryUserResponse>), 200)]
        public async Task<IEnumerable<CategoryUserResponse>> GetAll([FromQuery] int offset = 0,
            [FromQuery] int limit = 10)
        {
            var categoriesUsers = await categoryUserService.GetAll(offset, limit);
            return mapper.Map<IEnumerable<CategoryUserResponse>>(categoriesUsers);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CategoryUserResponse), 200)]
        public async Task<CategoryUserResponse> GetById([FromRoute] int id)
        {
            var categoryUser = await categoryUserService.GetById(id);
            return mapper.Map<CategoryUserResponse>(categoryUser);
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Insert([FromBody] InsertCategoryUserRequest request)
        {
            var model = mapper.Map<InsertCategoryUserModel>(request);
            await categoryUserService.Insert(model);
            return Ok("Ok");
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCategoryUserRequest request)
        {
            var model = mapper.Map<UpdateCategoryUserModel>(request);
            await categoryUserService.Update(id, model);
            return Ok("Ok");
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await categoryUserService.Delete(id);
            return Ok("Ok");
        }
    }
}
