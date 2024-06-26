using FeedManagerService.Models;

namespace FeedManagerService.Data
{
    public class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<FeedManagerDbContext>();
                if (context == null)
                {
                    throw new Exception("Null PaymentManagerDbContext");
                }
                SeedData(context);

            }
        }

        private static void SeedData(FeedManagerDbContext context)
        {

            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            // Seed data Comments
            if (!context.Comments.Any())
            {
                Console.WriteLine("--> Seeding  Comments data...");
                context.Comments.AddRange(
                    new Comment
                    {
                        Id = 1,
                        Content = "This is a comment",
                        UserId = 1,
                        PostId = 1
                    },
                    new Comment
                    {
                        Id = 2,
                        Content = "This is another comment",
                        UserId = 2,
                        PostId = 1
                    },
                    new Comment
                    {
                        Id = 3,
                        Content = "This is a third comment",
                        UserId = 3,
                        PostId = 1
                    },
                    new Comment
                    {
                        Id = 4,
                        Content = "This is a comment",
                        UserId = 1,
                        PostId = 2
                    },
                    new Comment
                    {
                        Id = 5,
                        Content = "This is another comment",
                        UserId = 2,
                        PostId = 2
                    },
                    new Comment
                    {
                        Id = 6,
                        Content = "This is a third comment",
                        UserId = 3,
                        PostId = 2
                    }
                    );

                context.Posts.AddRange(
                    new Post
                    {
                        Id = 1,
                        Content = "This is a post",
                        ImageUrl = "https://www.google.com",
                        UserId = 1
                    },
                    new Post
                    {
                        Id = 2,
                        Content = "This is another post",
                        ImageUrl = "https://www.google.com",
                        UserId = 2
                    },
                    new Post
                    {
                        Id = 3,
                        Content = "This is a third post",
                        ImageUrl = "https://www.google.com",
                        UserId = 3
                    }
                    );
                context.SaveChanges();
            }
        }
    }
   }
