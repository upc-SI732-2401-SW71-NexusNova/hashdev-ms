using AutoMapper;
using ConferenceManagerService.Data.Repositories;
using ConferenceManagerService.Dtos;
using ConferenceManagerService.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceManagerService.Controllers
{
    [ApiController]
    [Route("conferences")]
    [EnableCors("AllowOrigin")]
    public class ConferenceController : ControllerBase
    {
        private readonly IConferenceRepository _repository;
        private readonly IMapper _mapper;

        public ConferenceController(IConferenceRepository conferenceRepository , IMapper mapper)
        {
            _repository = conferenceRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetAllConferences()
        {
            var conferences = _repository.GetAllConferences();
            return Ok(_mapper.Map<IEnumerable<ConferenceReadDto>>(conferences));
        }

        [HttpGet("{id}", Name = "GetConferenceById")]
        public ActionResult GetConferenceById(int id)
        {
            var conference = _repository.GetConferenceById(id);
            return Ok(_mapper.Map<ConferenceReadDto>(conference));
        }

        [HttpPost]
        public ActionResult CreateConference(ConferenceCreateDto conferenceCreateDto)
        {
            var conferenceModel = _mapper.Map<Conference>(conferenceCreateDto);
            _repository.CreateConference(conferenceModel);
            _repository.SaveChanges();

            var conferenceReadDto = _mapper.Map<ConferenceReadDto>(conferenceModel);
            return CreatedAtRoute(nameof(GetConferenceById), new { Id = conferenceReadDto.Id }, conferenceReadDto);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteConference(int id)
        {
            var conference = _repository.GetConferenceById(id);
            _repository.DeleteConference(conference);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}
