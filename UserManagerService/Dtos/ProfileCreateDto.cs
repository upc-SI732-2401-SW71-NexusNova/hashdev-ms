namespace UserManagerService.Dtos
{
    public class ProfileCreateDto
    {
        public string FullName { get; set; }
        public string Bio { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string Location { get; set; }
        public string Website { get; set; }
        public string Github { get; set; }
        public int UserId { get; set; }
    }
}
