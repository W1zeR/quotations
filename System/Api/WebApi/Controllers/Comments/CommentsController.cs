using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Comments;
using WebApi.Controllers.Comments.Models;
using Comments.Models;
using Common.ModelValidator;
using Common.Responses.ErrorResponse;

namespace WebApi.Controllers.Comments
{
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    [ProducesResponseType(typeof(ErrorResponse), 500)]
    [Produces("application/json")]
    [Route("api/comments")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService commentService;
        private readonly IMapper mapper;
        private readonly IModelValidator<InsertCommentRequest> insertCommentRequestValidator;
        private readonly IModelValidator<UpdateCommentRequest> updateCommentRequestValidator;

        public CommentsController(
            ICommentService commentService,
            IMapper mapper,
            IModelValidator<InsertCommentRequest> insertCommentRequestValidator,
            IModelValidator<UpdateCommentRequest> updateCommentRequestValidator
        )
        {
            this.commentService = commentService;
            this.mapper = mapper;
            this.insertCommentRequestValidator = insertCommentRequestValidator;
            this.updateCommentRequestValidator = updateCommentRequestValidator;
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(IEnumerable<CommentResponse>), 200)]
        public async Task<IEnumerable<CommentResponse>> GetAll([FromQuery] int offset = 0, [FromQuery] int limit = 10)
        {
            var comments = await commentService.GetAll(offset, limit);
            return mapper.Map<IEnumerable<CommentResponse>>(comments);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CommentResponse), 200)]
        public async Task<CommentResponse> GetById([FromRoute] int id)
        {
            var comment = await commentService.GetById(id);
            return mapper.Map<CommentResponse>(comment);
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Insert([FromBody] InsertCommentRequest request)
        {
            insertCommentRequestValidator.Check(request);
            var model = mapper.Map<InsertCommentModel>(request);
            await commentService.Insert(model);
            return Ok();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentRequest request)
        {
            updateCommentRequestValidator.Check(request);
            var model = mapper.Map<UpdateCommentModel>(request);
            await commentService.Update(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await commentService.Delete(id);
            return Ok();
        }
    }
}
