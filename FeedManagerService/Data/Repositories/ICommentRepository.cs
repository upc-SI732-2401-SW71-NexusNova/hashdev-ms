using FeedManagerService.Models;

namespace FeedManagerService.Data.Repositories
{
    public interface ICommentRepository
    {
        bool SaveChanges();
        IEnumerable<Comment> GetAllComments();
        Comment GetCommentById(int id);
        void CreateComment(Comment comment);
        void UpdateComment(int id, Comment comment);
        void DeleteComment(Comment comment);
    }
}
