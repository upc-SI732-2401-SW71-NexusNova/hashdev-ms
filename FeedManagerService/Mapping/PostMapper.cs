using AutoMapper;
using FeedManagerService.Dtos;
using FeedManagerService.Models;

namespace FeedManagerService.Mapping
{
    public class PostMapper : Profile
    {
        public PostMapper()
        {
            CreateMap<Post, PostReadDto>();
            CreateMap<PostCreateDto, Post>();
        }
    }
}
