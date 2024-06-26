using System.ComponentModel.DataAnnotations;
using UserManagerService.Models;

namespace FeedManagerService.Models
{
    public class Post
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public int UserId { get; set; }

        public IList<Comment> Comments { get; set; }
    }
}
