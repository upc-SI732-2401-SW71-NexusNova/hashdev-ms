using AutoMapper;
using FeedManagerService.Data.Repositories;
using FeedManagerService.Dtos;
using FeedManagerService.Models;
using Microsoft.AspNetCore.Mvc;

namespace FeedManagerService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;

        public PostController(IMapper mapper , IPostRepository postRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PostReadDto>> GetAllPost()
        {
            Console.WriteLine("--> Getting all Posts");
            var posts = _postRepository.GetAllPosts();
            return Ok(_mapper.Map<IEnumerable<PostReadDto>>(posts));
        }

        [HttpGet("{id}", Name = "GetPostById")]
        public ActionResult<PostReadDto> GetPostById(int id)
        {
            Console.WriteLine($"--> Getting Post with id: {id}");
            var post = _postRepository.GetPostById(id);
            if (post != null)
            {
                return Ok(_mapper.Map<PostReadDto>(post));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<PostReadDto> CreatePost(PostCreateDto postCreateDto)
        {
            Console.WriteLine("--> Creating Post");
            var postModel = _mapper.Map<Post>(postCreateDto);
            _postRepository.CreatePost(postModel);
            _postRepository.SaveChanges();

            var postReadDto = _mapper.Map<PostReadDto>(postModel);

            return CreatedAtRoute(nameof(GetPostById), new { Id = postReadDto.Id }, postReadDto);
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePost(int id)
        {
            Console.WriteLine($"--> Deleting Post with id: {id}");
            var postModelFromRepo = _postRepository.GetPostById(id);
            if (postModelFromRepo == null)
            {
                return NotFound();
            }
            _postRepository.DeletePost(postModelFromRepo);
            _postRepository.SaveChanges();

            return NoContent();
        }
    }
}
