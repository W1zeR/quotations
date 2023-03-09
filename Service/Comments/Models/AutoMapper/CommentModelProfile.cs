﻿using AutoMapper;
using Context.Entities;

namespace Comments.Models.AutoMapper
{
    public class CommentModelProfile : Profile
    {
        public CommentModelProfile()
        {
            CreateMap<Comment, CommentModel>();
        }
    }
}
