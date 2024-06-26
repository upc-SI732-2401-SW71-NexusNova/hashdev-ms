using FeedManagerService.Models;

namespace FeedManagerService.Data.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly FeedManagerDbContext _context;

        public CommentRepository(FeedManagerDbContext context)
        {
            _context = context;
        }

        public void CreateComment(Comment comment)
        {
            if (comment == null) {
                throw new System.ArgumentNullException(nameof(comment));
            }
            _context.Comments.Add(comment);
        }

        public void DeleteComment(Comment comment)
        {
            if (comment == null) {
                throw new System.ArgumentNullException(nameof(comment));
            }
            _context.Comments.Remove(comment);
        }

        public IEnumerable<Comment> GetAllComments()
        {
            return _context.Comments;
        }

        public Comment GetCommentById(int id)
        {
            var comment = _context.Comments.Find(id);
            if (comment == null) {
                throw new System.ArgumentNullException(nameof(comment));
            }
            return comment;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateComment(int id, Comment comment)
        {
            var existingComment = _context.Comments.Find(id);
            if (existingComment == null) {
                throw new System.ArgumentNullException(nameof(existingComment));
            }
            if (comment == null) {
                throw new System.ArgumentNullException(nameof(comment));
            }
            existingComment.Content = comment.Content;
            existingComment.UserId = comment.UserId;
            existingComment.PostId = comment.PostId;
        }
    }
}
