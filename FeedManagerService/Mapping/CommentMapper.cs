using AutoMapper;
using FeedManagerService.Dtos;
using FeedManagerService.Models;

namespace FeedManagerService.Mapping
{
    public class CommentMapper : Profile
    {
        public CommentMapper()
        {
            CreateMap<Comment, CommentReadDto>();
            CreateMap<CommentCreateDto, Comment>();
        }
    }
}
