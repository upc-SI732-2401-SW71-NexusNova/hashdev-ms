using UserManagerService.Dtos;
using UserManagerService.Models;

namespace UserManagerService.Mapping
{
    public class ProfileMapper : AutoMapper.Profile
    {
        public ProfileMapper()
        {
            // Source -> Target
            CreateMap<Profile, ProfileReadDto>();
            CreateMap<ProfileCreateDto, Profile>();
        }
    }
}
