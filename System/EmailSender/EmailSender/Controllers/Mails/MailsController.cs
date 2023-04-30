using AutoMapper;
using Common.ModelValidator;
using Common.Responses.ErrorResponse;
using EmailSender.Controllers.Mails.Models;
using Mails;
using Mails.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmailSender.Controllers.Mails
{
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    [ProducesResponseType(typeof(ErrorResponse), 500)]
    [Produces("application/json")]
    [Route("api/mails")]
    [ApiController]
    public class MailsController : ControllerBase
    {
        private readonly IMailService mailService;
        private readonly IMapper mapper;
        private readonly IModelValidator<MailRequest> mailRequestValidator;

        public MailsController(
            IMailService mailService,
            IMapper mapper,
            IModelValidator<MailRequest> mailRequestValidator
        )
        {
            this.mailService = mailService;
            this.mapper = mapper;
            this.mailRequestValidator = mailRequestValidator;
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SendMail([FromBody] MailRequest request)
        {
            mailRequestValidator.Check(request);
            var model = mapper.Map<MailModel>(request);
            await mailService.SendAsync(model, new CancellationToken());
            return Ok("Ok");
        }
    }
}
