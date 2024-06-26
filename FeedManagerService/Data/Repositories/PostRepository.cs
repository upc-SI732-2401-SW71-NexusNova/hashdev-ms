using FeedManagerService.Models;

namespace FeedManagerService.Data.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly FeedManagerDbContext _context;

        public PostRepository(FeedManagerDbContext context)
        {
            _context = context;
        }

        public void CreatePost(Post post)
        {
            if (post == null) {
                throw new System.ArgumentNullException(nameof(post));
            }
            _context.Posts.Add(post);
        }

        public void DeletePost(Post post)
        {
            if (post == null) {
                throw new System.ArgumentNullException(nameof(post));
            }
            _context.Posts.Remove(post);
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _context.Posts;
        }

        public Post GetPostById(int id)
        {
            var post = _context.Posts.Find(id);
            if (post == null) {
                throw new System.ArgumentNullException(nameof(post));
            }
            return post;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdatePost(int id, Post post)
        {
            var existingPost = _context.Posts.Find(id);
            if (existingPost == null) {
                throw new System.ArgumentNullException(nameof(existingPost));
            }
            if (post == null) {
                throw new System.ArgumentNullException(nameof(post));
            }
            existingPost.Content = post.Content;
            existingPost.ImageUrl= post.ImageUrl;
            existingPost.UserId = post.UserId;

        }
    }
}
