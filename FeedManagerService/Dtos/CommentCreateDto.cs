﻿namespace FeedManagerService.Dtos
{
    public class CommentCreateDto
    {
        public string Content { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
}
