using System.ComponentModel.DataAnnotations;

namespace FeedManagerService.Dtos
{
    public class PostReadDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public int UserId { get; set; }
    }
}
