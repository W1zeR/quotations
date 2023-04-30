using AutoMapper;
using Categories;
using Categories.Models;
using CategoriesQuotations;
using CategoriesUsers;
using Common.ModelValidator;
using Common.Responses.ErrorResponse;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Categories.Models;
using WebApi.Controllers.Quotations.Models;

namespace WebApi.Controllers.Categories
{
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    [ProducesResponseType(typeof(ErrorResponse), 500)]
    [Produces("application/json")]
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        private readonly ICategoryQuotationService categoryQuotationService;
        private readonly ICategoryUserService categoryUserService;
        private readonly IMapper mapper;
        private readonly IModelValidator<InsertCategoryRequest> insertCategoryRequestValidator;
        private readonly IModelValidator<UpdateCategoryRequest> updateCategoryRequestValidator;

        public CategoriesController(
            ICategoryService categoryService,
            ICategoryQuotationService categoryQuotationService,
            ICategoryUserService categoryUserService,
            IMapper mapper,
            IModelValidator<InsertCategoryRequest> insertCategoryRequestValidator,
            IModelValidator<UpdateCategoryRequest> updateCategoryRequestValidator
        )
        {
            this.categoryService = categoryService;
            this.categoryQuotationService = categoryQuotationService;
            this.categoryUserService = categoryUserService;
            this.mapper = mapper;
            this.insertCategoryRequestValidator = insertCategoryRequestValidator;
            this.updateCategoryRequestValidator = updateCategoryRequestValidator;
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(IEnumerable<CategoryResponse>), 200)]
        public async Task<IEnumerable<CategoryResponse>> GetAll([FromQuery] int offset = 0, [FromQuery] int limit = 10)
        {
            var categories = await categoryService.GetAll(offset, limit);
            return mapper.Map<IEnumerable<CategoryResponse>>(categories);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CategoryResponse), 200)]
        public async Task<CategoryResponse> GetById([FromRoute] int id)
        {
            var category = await categoryService.GetById(id);
            return mapper.Map<CategoryResponse>(category);
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Insert([FromBody] InsertCategoryRequest request)
        {
            insertCategoryRequestValidator.Check(request);
            var model = mapper.Map<InsertCategoryModel>(request);
            await categoryService.Insert(model);
            return Ok("Ok");
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCategoryRequest request)
        {
            updateCategoryRequestValidator.Check(request);
            var model = mapper.Map<UpdateCategoryModel>(request);
            await categoryService.Update(id, model);
            return Ok("Ok");
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await categoryService.Delete(id);
            return Ok("Ok");
        }

        [HttpGet("{id}/quotations")]
        [ProducesResponseType(typeof(IEnumerable<QuotationResponse>), 200)]
        public async Task<IEnumerable<QuotationResponse>> GetQuotationsByCategoryId(int id)
        {
            var quotations = await categoryQuotationService.GetQuotationsByCategoryId(id);
            return mapper.Map<IEnumerable<QuotationResponse>>(quotations);
        }

        //[HttpGet("{id}/users")]
        //[ProducesResponseType(typeof(IEnumerable<UserResponse>), 200)]
        //public async Task<IEnumerable<UserResponse>> GetUsersByCategoryId(int id)
        //{
        //    var quotations = await categoryUserService.GetUsersByCategoryId(id);
        //    return mapper.Map<IEnumerable<UserResponse>>(quotations);
        //}
    }
}
