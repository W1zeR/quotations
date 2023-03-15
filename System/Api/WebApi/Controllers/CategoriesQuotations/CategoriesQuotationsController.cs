using AutoMapper;
using CategoriesQuotations;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.CategoriesQuotations.Models;
using CategoriesQuotations.Models;

namespace WebApi.Controllers.CategoriesQuotations
{
    [Produces("application/json")]
    [Route("api/categories-quotations")]
    [ApiController]
    public class CategoriesQuotationsController : ControllerBase
    {
        private readonly ICategoryQuotationService categoryQuotationService;
        private readonly IMapper mapper;

        public CategoriesQuotationsController(
            ICategoryQuotationService categoryQuotationService,
            IMapper mapper
        )
        {
            this.categoryQuotationService = categoryQuotationService;
            this.mapper = mapper;
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(IEnumerable<CategoryQuotationResponse>), 200)]
        public async Task<IEnumerable<CategoryQuotationResponse>> GetAll([FromQuery] int offset = 0, 
            [FromQuery] int limit = 10)
        {
            var categoriesQuotations = await categoryQuotationService.GetAll(offset, limit);
            return mapper.Map<IEnumerable<CategoryQuotationResponse>>(categoriesQuotations);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CategoryQuotationResponse), 200)]
        public async Task<CategoryQuotationResponse> GetById([FromRoute] int id)
        {
            var categoryQuotation = await categoryQuotationService.GetById(id);
            return mapper.Map<CategoryQuotationResponse>(categoryQuotation);
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Insert([FromBody] InsertCategoryQuotationRequest request)
        {
            var model = mapper.Map<InsertCategoryQuotationModel>(request);
            await categoryQuotationService.Insert(model);
            return Ok();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCategoryQuotationRequest request)
        {
            var model = mapper.Map<UpdateCategoryQuotationModel>(request);
            await categoryQuotationService.Update(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await categoryQuotationService.Delete(id);
            return Ok();
        }
    }
}
