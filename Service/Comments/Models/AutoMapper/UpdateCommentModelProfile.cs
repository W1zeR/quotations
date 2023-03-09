using AutoMapper;
using Context.Entities;

namespace Comments.Models.AutoMapper
{
    public class UpdateCommentModelProfile : Profile
    {
        public UpdateCommentModelProfile()
        {
            CreateMap<UpdateCommentModel, Comment>();
        }
    }
}
