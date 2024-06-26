using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using UserManagerService.Data.Repositories;
using UserManagerService.Dtos;
using UserManagerService.Models;

namespace UserManagerService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public ActionResult<UserReadDto> Login([FromQuery] string email, [FromQuery] string password)
        {
            Console.WriteLine("--> Logging in user...");

            try
            {
                _userRepository.Login(email, password);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }

            var user = _userRepository.GetUserByEmail(email);

            var userReadDto = _mapper.Map<UserReadDto>(user);
            return Ok(userReadDto);
        }




        [HttpPost("register")]
        public ActionResult<UserReadDto> Register(UserCreateDto userCreateDto)
        {
            Console.WriteLine("--> Registering user...");
            var userModel = _mapper.Map<User>(userCreateDto);
            _userRepository.Register(userModel);
            _userRepository.SaveChanges();

            var userReadDto = _mapper.Map<UserReadDto>(userModel);
            return CreatedAtRoute(nameof(GetUserById), new { Id = userReadDto.Id }, userReadDto);
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserReadDto>> GetAllUsers()
        {
            Console.WriteLine("--> Getting all users...");
            var users = _userRepository.GetAllUsers();
            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(users));
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public ActionResult<UserReadDto> GetUserById(int id)
        {
            Console.WriteLine($"--> Getting user by id: {id}");
            var user = _userRepository.GetUserById(id);
            return Ok(_mapper.Map<UserReadDto>(user));
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            Console.WriteLine($"--> Deleting user by id: {id}");
            var user = _userRepository.GetUserById(id);
            _userRepository.DeleteUser(user);
            _userRepository.SaveChanges();
            return NoContent();
        }

    }
}
