using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using UserManagerService.Data.Repositories;
using UserManagerService.Dtos;

namespace UserManagerService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly AutoMapper.IMapper _mapper;
        private readonly IProfileRepository _repository;

        public ProfileController(AutoMapper.IMapper mapper, IProfileRepository profileRepository)
        {
            _mapper = mapper;
            _repository = profileRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProfileReadDto>> GetAllProfiles()
        {
            Console.WriteLine("--> Getting all profiles...");
            var profiles = _repository.GetAllProfiles();
            return Ok(_mapper.Map<IEnumerable<ProfileReadDto>>(profiles));
        }

        [HttpGet("{id}", Name = "GetProfileById")]
        public ActionResult<ProfileReadDto> GetProfileById(int id)
        {
            Console.WriteLine($"--> Getting profile by id: {id}");
            var profile = _repository.GetProfileById(id);
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ProfileReadDto>(profile));
        }

        [HttpPost]
        public ActionResult<ProfileReadDto> CreateProfile([FromBody] ProfileCreateDto profileCreateDto)
        {
            Console.WriteLine("--> Creating profile...");
            var profileModel = _mapper.Map<Models.Profile>(profileCreateDto);
            _repository.CreateProfile(profileModel);
            _repository.SaveChanges();

            var profileReadDto = _mapper.Map<ProfileReadDto>(profileModel);

            return CreatedAtRoute("GetProfileById", new { id = profileReadDto.Id }, profileReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProfile(int id, [FromBody] ProfileCreateDto profileCreateDto)
        {
            Console.WriteLine($"--> Updating profile with id: {id}");
            var profileModel = _repository.GetProfileById(id);
            if (profileModel == null)
            {
                return NotFound();
            }
            _mapper.Map(profileCreateDto, profileModel);
            _repository.UpdateProfile(id, profileModel);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProfile(int id)
        {
            Console.WriteLine($"--> Deleting profile with id: {id}");
            var profileModel = _repository.GetProfileById(id);
            if (profileModel == null)
            {
                return NotFound();
            }
            _repository.DeleteProfile(profileModel);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}
