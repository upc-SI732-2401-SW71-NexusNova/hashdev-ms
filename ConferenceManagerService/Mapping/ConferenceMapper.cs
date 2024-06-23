using AutoMapper;
using ConferenceManagerService.Dtos;
using ConferenceManagerService.Models;

namespace ConferenceManagerService.Mapping
{
    public class ConferenceMapper : Profile
    {
        public ConferenceMapper()
        {
            // Source -> Target
            CreateMap<Conference, ConferenceReadDto>();
            CreateMap<ConferenceCreateDto, Conference>();
        }
    }
}
