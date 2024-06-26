using FeedManagerService.Models;

namespace FeedManagerService.Data.Repositories
{
    public interface IPostRepository
    {
        bool SaveChanges();
        IEnumerable<Post> GetAllPosts();
        Post GetPostById(int id);
        void CreatePost(Post post);
        void UpdatePost(int id, Post post);
        void DeletePost(Post post);
    }
}
