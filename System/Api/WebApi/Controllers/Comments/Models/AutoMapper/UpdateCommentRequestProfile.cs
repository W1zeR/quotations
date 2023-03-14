using AutoMapper;
using Comments.Models;

namespace WebApi.Controllers.Comments.Models.AutoMapper
{
    public class UpdateCommentRequestProfile : Profile
    {
        public UpdateCommentRequestProfile() 
        {
            CreateMap<UpdateCommentRequest, UpdateCommentModel>();
        }
    }
}
