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
                context.Users.AddRange(
                    new User
                    {
                        Id = 1,
                        FullName = "John Doe",
                        Email = "johndoe@example.com",
                        Password = "password1"
                    },
                    new User
                    {
                        Id = 2,
                        FullName = "Maria Park",
                        Email = "mariapark@example.com",
                        Password = "password2"
                    },
                    new User
                    {
                        Id = 3,
                        FullName = "Michael Smith",
                        Email = "michaelsmith@example.com",
                        Password = "password3"
                    },
                    new User
                    {
                        Id = 4,
                        FullName = "Emily Johnson",
                        Email = "emilyjohnson@example.com",
                        Password = "password4"
                    },
                    new User
                    {
                        Id = 5,
                        FullName = "David Brown",
                        Email = "davidbrown@example.com",
                        Password = "password5"
                    },
                    new User
                    {
                        Id = 6,
                        FullName = "Sophia Wilson",
                        Email = "sophiawilson@example.com",
                        Password = "password6"
                    },
                    new User
                    {
                        Id = 7,
                        FullName = "Daniel Taylor",
                        Email = "danieltaylor@example.com",
                        Password = "password7"
                    },
                    new User
                    {
                        Id = 8,
                        FullName = "Olivia Anderson",
                        Email = "oliviaanderson@example.com",
                        Password = "password8"
                    },
                    new User
                    {
                        Id = 9,
                        FullName = "James Martinez",
                        Email = "jamesmartinez@example.com",
                        Password = "password9"
                    },
                    new User
                    {
                        Id = 10,
                        FullName = "Emma Thompson",
                        Email = "emmathompson@example.com",
                        Password = "password10"
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
