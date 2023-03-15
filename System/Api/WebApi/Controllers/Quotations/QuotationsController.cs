using AutoMapper;
using Categories.Models;
using Categories;
using CategoriesQuotations;
using CategoriesUsers;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Categories.Models;
using WebApi.Controllers.Quotations.Models;
using Quotations;
using Comments;
using Quotations.Models;
using WebApi.Controllers.Comments.Models;

namespace WebApi.Controllers.Quotations
{
    [Produces("application/json")]
    [Route("api/quotations")]
    [ApiController]
    public class QuotationsController : ControllerBase
    {
        private readonly IQuotationService quotationService;
        private readonly ICategoryQuotationService categoryQuotationService;
        private readonly ICommentService commentService;
        private readonly IMapper mapper;
        private readonly IValidator<InsertQuotationRequest> insertQuotationRequestValidator;
        private readonly IValidator<UpdateQuotationRequest> updateQuotationRequestValidator;

        public QuotationsController(
            IQuotationService quotationService,
            ICategoryQuotationService categoryQuotationService,
            ICommentService commentService,
            IMapper mapper,
            IValidator<InsertQuotationRequest> insertQuotationRequestValidator,
            IValidator<UpdateQuotationRequest> updateQuotationRequestValidator
        )
        {
            this.quotationService = quotationService;
            this.categoryQuotationService = categoryQuotationService;
            this.commentService = commentService;
            this.mapper = mapper;
            this.insertQuotationRequestValidator = insertQuotationRequestValidator;
            this.updateQuotationRequestValidator = updateQuotationRequestValidator;
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(IEnumerable<QuotationResponse>), 200)]
        public async Task<IEnumerable<QuotationResponse>> GetAll([FromQuery] int offset = 0, [FromQuery] int limit = 10)
        {
            var quotations = await quotationService.GetAll(offset, limit);
            return mapper.Map<IEnumerable<QuotationResponse>>(quotations);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(QuotationResponse), 200)]
        public async Task<QuotationResponse> GetById([FromRoute] int id)
        {
            var quotation = await quotationService.GetById(id);
            return mapper.Map<QuotationResponse>(quotation);
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Insert([FromBody] InsertQuotationRequest request)
        {
            var validationResult = insertQuotationRequestValidator.Validate(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(new ValidationException(validationResult.Errors));
            }
            var model = mapper.Map<InsertQuotationModel>(request);
            await quotationService.Insert(model);
            return Ok();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateQuotationRequest request)
        {
            var validationResult = updateQuotationRequestValidator.Validate(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(new ValidationException(validationResult.Errors));
            }
            var model = mapper.Map<UpdateQuotationModel>(request);
            await quotationService.Update(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await quotationService.Delete(id);
            return Ok();
        }

        [HttpGet("{id}/categories")]
        [ProducesResponseType(typeof(IEnumerable<CategoryResponse>), 200)]
        public async Task<IEnumerable<CategoryResponse>> GetCategoriesByQuotationId(int id)
        {
            var categories = await categoryQuotationService.GetCategoriesByQuotationId(id);
            return mapper.Map<IEnumerable<CategoryResponse>>(categories);
        }

        [HttpGet("{id}/comments")]
        [ProducesResponseType(typeof(IEnumerable<CommentResponse>), 200)]
        public async Task<IEnumerable<CommentResponse>> GetCommentsByQuotationId(int id)
        {
            var comments = await commentService.GetByQuotationId(id);
            return mapper.Map<IEnumerable<CommentResponse>>(comments);
        }
    }
}
