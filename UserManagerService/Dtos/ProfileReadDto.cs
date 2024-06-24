using System.ComponentModel.DataAnnotations;

namespace UserManagerService.Dtos
{
    public class ProfileReadDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string Location { get; set; }
        public string Website { get; set; }
        public string Github { get; set; }
        public int UserId { get; set; }
    }
}
