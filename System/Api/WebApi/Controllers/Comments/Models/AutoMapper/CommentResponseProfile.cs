using AutoMapper;
using Comments.Models;

namespace WebApi.Controllers.Comments.Models.AutoMapper
{
    public class CommentResponseProfile : Profile
    {
        public CommentResponseProfile()
        {
            CreateMap<CommentModel, CommentResponse>();
        }
    }
}
