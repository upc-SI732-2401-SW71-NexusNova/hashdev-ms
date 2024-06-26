using System.ComponentModel.DataAnnotations;
using UserManagerService.Models;

namespace FeedManagerService.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int PostId { get; set; }
        public User User { get; set; }
        public Post Post { get; set; }
    }
}
