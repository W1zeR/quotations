using AutoMapper;
using Comments.Models;

namespace WebApi.Controllers.Comments.Models.AutoMapper
{
    public class InsertCommentRequestProfile : Profile
    {
        public InsertCommentRequestProfile()
        {
            CreateMap<InsertCommentRequest, InsertCommentModel>();
        }
    }
}
