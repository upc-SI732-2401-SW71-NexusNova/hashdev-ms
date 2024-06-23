using AutoMapper;
using UserManagerService.Dtos;
using UserManagerService.Models;

namespace UserManagerService.Mapping
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            // Source -> Target
            CreateMap<User, UserReadDto>();
            CreateMap<User, LoginDto>();
            CreateMap<UserCreateDto, User>();
        }
    }
}
