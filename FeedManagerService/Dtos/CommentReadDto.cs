namespace FeedManagerService.Dtos
{
    public class CommentReadDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
}
