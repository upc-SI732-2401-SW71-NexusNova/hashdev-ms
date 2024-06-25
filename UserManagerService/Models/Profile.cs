using System.ComponentModel.DataAnnotations;

namespace UserManagerService.Models
{
    public class Profile
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Bio { get; set; }

        [Required]
        public string ProfilePictureUrl { get; set; }

        [Required]
        public string Location { get; set; }

        public string Website { get; set; }

        public string Github { get; set; }

        [Required]
        public int UserId { get; set; }

        public User User { get; set; }
    }
}
