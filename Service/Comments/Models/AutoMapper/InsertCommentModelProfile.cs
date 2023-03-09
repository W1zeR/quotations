using AutoMapper;
using Context.Entities;

namespace Comments.Models.AutoMapper
{
    public class InsertCommentModelProfile : Profile
    {
        public InsertCommentModelProfile()
        {
            CreateMap<InsertCommentModel, Comment>();
        }
    }
}
