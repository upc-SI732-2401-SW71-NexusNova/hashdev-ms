using AutoMapper;
using FeedManagerService.Data.Repositories;
using FeedManagerService.Dtos;
using FeedManagerService.Models;
using Microsoft.AspNetCore.Mvc;

namespace FeedManagerService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICommentRepository _commentRepository;

        public CommentController(IMapper mapper, ICommentRepository commentRepository)
        {
            _mapper = mapper;
            _commentRepository = commentRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommentReadDto>> GetAllComments()
        {
            Console.WriteLine("--> Getting all Comments");
            var comments = _commentRepository.GetAllComments();
            return Ok(_mapper.Map<IEnumerable<CommentReadDto>>(comments));
        }

        [HttpGet("{id}", Name = "GetCommentById")]
        public ActionResult<CommentReadDto> GetCommentById(int id)
        {
            Console.WriteLine($"--> Getting Comment with id: {id}");
            var comment = _commentRepository.GetCommentById(id);
            if (comment != null)
            {
                return Ok(_mapper.Map<CommentReadDto>(comment));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<CommentReadDto> CreateComment(CommentCreateDto commentCreateDto)
        {
            Console.WriteLine("--> Creating Comment");
            var commentModel = _mapper.Map<Comment>(commentCreateDto);
            _commentRepository.CreateComment(commentModel);
            _commentRepository.SaveChanges();

            var commentReadDto = _mapper.Map<CommentReadDto>(commentModel);

            return CreatedAtRoute(nameof(GetCommentById), new { Id = commentReadDto.Id }, commentReadDto);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteComment(int id)
        {
            Console.WriteLine($"--> Deleting Comment with id: {id}");
            var commentModelFromRepo = _commentRepository.GetCommentById(id);
            if (commentModelFromRepo == null)
            {
                return NotFound();
            }
            _commentRepository.DeleteComment(commentModelFromRepo);
            _commentRepository.SaveChanges();

            return NoContent();
        }
    }
}
