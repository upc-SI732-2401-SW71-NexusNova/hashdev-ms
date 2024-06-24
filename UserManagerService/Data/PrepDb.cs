using Microsoft.IdentityModel.Tokens;
using UserManagerService.Models;

namespace UserManagerService.Data
{
    public class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<UserManagerDbContext>();
                if (context == null)
                {
                    throw new Exception("Null UserManagerDbContext");
                }
                SeedData(context);
            }
        }

        private static void SeedData(UserManagerDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (!context.Users.Any())
            {
                Console.WriteLine("--> Seeding data...");
                // Seed data User
                context.Users.AddRange(
                    new User
                    {
                        Id = 1,
                        Username = "JohnDoe",
                        Email = "johndoe@example.com",
                        Password = "password1"
                    },
                    new User
                    {
                        Id = 2,
                        Username = "MariaPark",
                        Email = "mariapark@example.com",
                        Password = "password2"
                    },
                    new User
                    {
                        Id = 3,
                        Username = "MichaelSmith",
                        Email = "michaelsmith@example.com",
                        Password = "password3"
                    },
                    new User
                    {
                        Id = 4,
                        Username = "EmilyJohnson",
                        Email = "emilyjohnson@example.com",
                        Password = "password4"
                    },
                    new User
                    {
                        Id = 5,
                        Username = "DavidBrown",
                        Email = "davidbrown@example.com",
                        Password = "password5"
                    },
                    new User
                    {
                        Id = 6,
                        Username = "SophiaWilson",
                        Email = "sophiawilson@example.com",
                        Password = "password6"
                    },
                    new User
                    {
                        Id = 7,
                        Username = "DanielTaylor",
                        Email = "danieltaylor@example.com",
                        Password = "password7"
                    },
                    new User
                    {
                        Id = 8,
                        Username = "OliviaAnderson",
                        Email = "oliviaanderson@example.com",
                        Password = "password8"
                    },
                    new User
                    {
                        Id = 9,
                        Username = "JamesMartinez",
                        Email = "jamesmartinez@example.com",
                        Password = "password9"
                    },
                    new User
                    {
                        Id = 10,
                        Username = "EmmaThompson",
                        Email = "emmathompson@example.com",
                        Password = "password10"
                    }
                );
                // Seed data Profile
                context.Profiles.AddRange(
                    new Profile
                    {
                        Id = 1,
                        FullName = "John Doe",
                        Bio = "Software Engineer",
                        ProfilePictureUrl = "https://randomuser.me/api/portraits/med/men/75.jpg",
                        Location = "New York, USA",
                        Website = "https://johndoe.com",
                        Github = "https://github.com/johndoe",
                        UserId = 1
                    },
                    new Profile
                    {
                        Id = 2,
                        FullName = "Maria Park",
                        Bio = "Web Developer",
                        ProfilePictureUrl = "https://randomuser.me/api/portraits/med/women/82.jpg",
                        Location = "San Francisco, USA",
                        Website = "https://mariapark.com",
                        Github = "https://github.com/mariapark",
                        UserId = 2
                    },
                    new Profile
                    {
                        Id = 3,
                        FullName = "Michael Smith",
                        Bio = "Data Scientist",
                        ProfilePictureUrl = "https://randomuser.me/api/portraits/med/men/12.jpg",
                        Location = "Chicago, USA",
                        Website = "https://michaelsmith.com",
                        Github = "https://github.com/michaelsmith",
                        UserId = 3
                    },
                    new Profile
                    {
                        Id = 4,
                        FullName = "Emily Johnson",
                        Bio = "UI/UX Designer",
                        ProfilePictureUrl = "https://randomuser.me/api/portraits/med/women/45.jpg",
                        Location = "Los Angeles, USA",
                        Website = "https://emilyjohnson.com",
                        Github = "https://github.com/emilyjohnson",
                        UserId = 4
                    },
                    new Profile
                    {
                        Id = 5,
                        FullName = "David Brown",
                        Bio = "Software Engineer",
                        ProfilePictureUrl = "https://randomuser.me/api/portraits/med/men/34.jpg",
                        Location = "Seattle, USA",
                        Website = "https://davidbrown.com",
                        Github = "https://github.com/davidbrown",
                        UserId = 5
                    },
                    new Profile
                    {
                        Id = 6,
                        FullName = "Sophia Wilson",
                        Bio = "Product Manager",
                        ProfilePictureUrl = "https://randomuser.me/api/portraits/med/women/67.jpg",
                        Location = "Austin, USA",
                        Website = "https://sophiawilson.com",
                        Github = "https://github.com/sophiawilson",
                        UserId = 6
                    },
                    new Profile
                    {
                        Id = 7,
                        FullName = "Daniel Taylor",
                        Bio = "Software Developer",
                        ProfilePictureUrl = "https://randomuser.me/api/portraits/med/men/56.jpg",
                        Location = "Boston, USA",
                        Website = "https://danieltaylor.com",
                        Github = "https://github.com/danieltaylor",
                        UserId = 7
                    },
                    new Profile
                    {
                        Id = 8,
                        FullName = "Olivia Anderson",
                        Bio = "Frontend Developer",
                        ProfilePictureUrl = "https://randomuser.me/api/portraits/med/women/23.jpg",
                        Location = "Denver, USA",
                        Website = "https://oliviaanderson.com",
                        Github = "https://github.com/oliviaanderson",
                        UserId = 8
                    },
                    new Profile
                    {
                        Id = 9,
                        FullName = "James Martinez",
                        Bio = "Backend Developer",
                        ProfilePictureUrl = "https://randomuser.me/api/portraits/med/men/89.jpg",
                        Location = "Houston, USA",
                        Website = "https://jamesmartinez.com",
                        Github = "https://github.com/jamesmartinez",
                        UserId = 9
                    },
                    new Profile
                    {
                        Id = 10,
                        FullName = "Emma Thompson",
                        Bio = "Mobile App Developer",
                        ProfilePictureUrl = "https://randomuser.me/api/portraits/med/women/39.jpg",
                        Location = "Miami, USA",
                        Website = "https://emmathompson.com",
                        Github = "https://github.com/emmathompson",
                        UserId = 10
                    }
                );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}
