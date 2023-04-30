using AutoMapper;
using Mails.Models;

namespace EmailSender.Controllers.Mails.Models.AutoMapper
{
    public class MailRequestProfile : Profile
    {
        public MailRequestProfile()
        {
            CreateMap<MailRequest, MailModel>();
        }
    }
}
