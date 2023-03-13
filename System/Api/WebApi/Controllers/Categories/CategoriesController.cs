using AutoMapper;
using Categories;
using Categories.Models;
using CategoriesQuotations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Categories.Models;

namespace WebApi.Controllers.Categories
{
    [Produces("application/json")]
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        private readonly ICategoryQuotationService categoryQuotationService;
        private readonly IMapper mapper;
        private readonly IValidator<InsertCategoryRequest> insertCategoryRequestValidator;
        private readonly IValidator<UpdateCategoryRequest> updateCategoryRequestValidator;

        public CategoriesController(
            ICategoryService categoryService,
            ICategoryQuotationService categoryQuotationService,
            IMapper mapper,
            IValidator<InsertCategoryRequest> insertCategoryRequestValidator,
            IValidator<UpdateCategoryRequest> updateCategoryRequestValidator
        )
        {
            this.categoryService = categoryService;
            this.categoryQuotationService = categoryQuotationService;
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Insert([FromBody] InsertCategoryRequest request)
        {
            var validationResult = insertCategoryRequestValidator.Validate(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(new ValidationException(validationResult.Errors));
            }
            var model = mapper.Map<InsertCategoryModel>(request);
            await categoryService.Insert(model);
            return Ok();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCategoryRequest request)
        {
            var validationResult = updateCategoryRequestValidator.Validate(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(new ValidationException(validationResult.Errors));
            }
            var model = mapper.Map<UpdateCategoryModel>(request);
            await categoryService.Update(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await categoryService.Delete(id);
            return Ok();
        }

        //[HttpGet("{id}/quotations")]
        //[ProducesResponseType(typeof(IEnumerable<QuotationResponse>), 200)]
        //public async Task<IEnumerable<QuotationResponse>> GetQuotationsByCategoryId(int id)
        //{
        //    var quotations = await categoryQuotationService.GetQuotationsByCategoryId(id);
        //    return mapper.Map<IEnumerable<QuotationResponse>>(quotations);
        //}
    }
}
