using UserManagerService.Dtos;
using UserManagerService.Models;

namespace UserManagerService.Mapping
{
    public class UserMapper : AutoMapper.Profile
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
