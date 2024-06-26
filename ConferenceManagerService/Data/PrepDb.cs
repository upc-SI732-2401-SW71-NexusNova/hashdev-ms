using ConferenceManagerService.Models;

namespace ConferenceManagerService.Data
{
    public class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ConferenceManagerDbContext>();
                if (context == null)
                {
                    throw new Exception(" ConferenceManagerDbContext is null.");
                }
                SeedData(context);

            }
        }

        public static void SeedData(ConferenceManagerDbContext context)
        {
            if (!context.Conferences.Any())
            {
                Console.WriteLine("--> Seeding data...");
                context.Conferences.AddRange(
                    // Id , Name , Image, Description, Price, Date, Time, Location, UserId
                    new Conference() { Id = 1, Name = "Dotnet Conference", Image = "https://cdn.plainconcepts.com/wp-content/uploads/2023/05/DotNet-2023.jpg", Description = "Event most famous of .NET developers in the world", Price = "20", Date = "08-10-2024", Time = "08:00", Location = "Virtual", UserId = 1 },
                    new Conference() { Id = 2, Name = "Java Conference", Image = "https://cdn.plainconcepts.com/wp-content/uploads/2023/05/Java-2023.jpg", Description = "Annual conference for Java developers", Price = "15", Date = "10-15-2024", Time = "09:00", Location = "Virtual", UserId = 2 },
                    new Conference() { Id = 3, Name = "Python Conference", Image = "https://cdn.plainconcepts.com/wp-content/uploads/2023/05/Python-2023.jpg", Description = "Gathering of Python enthusiasts", Price = "10", Date = "12-05-2024", Time = "10:30", Location = "Virtual", UserId = 3 },
                    new Conference() { Id = 4, Name = "JavaScript Conference", Image = "https://cdn.plainconcepts.com/wp-content/uploads/2023/05/JavaScript-2023.jpg", Description = "Conference for JavaScript developers", Price = "25", Date = "06-20-2024", Time = "13:45", Location = "Virtual", UserId = 4 },
                    new Conference() { Id = 5, Name = "Ruby Conference", Image = "https://cdn.plainconcepts.com/wp-content/uploads/2023/05/Ruby-2023.jpg", Description = "Annual Ruby conference", Price = "30", Date = "09-30-2024", Time = "15:00", Location = "Virtual", UserId = 5 },
                    new Conference() { Id = 6, Name = "C# Conference", Image = "https://cdn.plainconcepts.com/wp-content/uploads/2023/05/CSharp-2023.jpg", Description = "Conference for C# developers", Price = "20", Date = "07-12-2024", Time = "16:30", Location = "Virtual", UserId = 6 },
                    new Conference() { Id = 7, Name = "PHP Conference", Image = "https://cdn.plainconcepts.com/wp-content/uploads/2023/05/PHP-2023.jpg", Description = "Annual PHP conference", Price = "15", Date = "11-08-2024", Time = "18:15", Location = "Virtual", UserId = 7 },
                    new Conference() { Id = 8, Name = "Swift Conference", Image = "https://cdn.plainconcepts.com/wp-content/uploads/2023/05/Swift-2023.jpg", Description = "Conference for Swift developers", Price = "25", Date = "05-25-2024", Time = "20:00", Location = "Virtual", UserId = 8 },
                    new Conference() { Id = 9, Name = "Go Conference", Image = "https://cdn.plainconcepts.com/wp-content/uploads/2023/05/Go-2023.jpg", Description = "Annual Go conference", Price = "10", Date = "10-01-2024", Time = "09:30", Location = "Virtual", UserId = 9 },
                    new Conference() { Id = 10, Name = "Rust Conference", Image = "https://cdn.plainconcepts.com/wp-content/uploads/2023/05/Rust-2023.jpg", Description = "Conference for Rust developers", Price = "15", Date = "11-15-2024", Time = "11:45", Location = "Virtual", UserId = 10 }
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
