using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Subscriptions;
using WebApi.Controllers.Subscriptions.Models;
using Subscriptions.Models;

namespace WebApi.Controllers.Subscriptions
{
    [Produces("application/json")]
    [Route("api/subscriptions")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {
        private readonly ISubscriptionService subscriptionService;
        private readonly IMapper mapper;

        public SubscriptionsController(
            ISubscriptionService subscriptionService,
            IMapper mapper
        )
        {
            this.subscriptionService = subscriptionService;
            this.mapper = mapper;
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(IEnumerable<SubscriptionResponse>), 200)]
        public async Task<IEnumerable<SubscriptionResponse>> GetAll([FromQuery] int offset = 0,
            [FromQuery] int limit = 10)
        {
            var subscriptions = await subscriptionService.GetAll(offset, limit);
            return mapper.Map<IEnumerable<SubscriptionResponse>>(subscriptions);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SubscriptionResponse), 200)]
        public async Task<SubscriptionResponse> GetById([FromRoute] int id)
        {
            var subscription = await subscriptionService.GetById(id);
            return mapper.Map<SubscriptionResponse>(subscription);
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Insert([FromBody] InsertSubscriptionRequest request)
        {
            var model = mapper.Map<InsertSubscriptionModel>(request);
            await subscriptionService.Insert(model);
            return Ok();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateSubscriptionRequest request)
        {
            var model = mapper.Map<UpdateSubscriptionModel>(request);
            await subscriptionService.Update(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await subscriptionService.Delete(id);
            return Ok();
        }
    }
}
