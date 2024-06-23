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
                    new Conference() { Id = 1, AuthorId = 1, Title = "DotNetConference", Content = "The largest conference for .NET developers", DateConference = DateTime.Parse("2024-06-23"), Location = "Lima, Peru", NumberTickets = 1000, Price = 100.0f },
                    new Conference() { Id = 2, AuthorId = 2, Title = "TechSummit", Content = "A technology conference for industry professionals", DateConference = DateTime.Parse("2024-07-15"), Location = "New York, USA", NumberTickets = 500, Price = 50.0f },
                    new Conference() { Id = 3, AuthorId = 2, Title = "CodeCamp", Content = "A community-driven event for developers", DateConference = DateTime.Parse("2024-08-10"), Location = "London, UK", NumberTickets = 800, Price = 75.0f },
                    new Conference() { Id = 4, AuthorId = 3, Title = "DevCon", Content = "A conference focused on software development", DateConference = DateTime.Parse("2024-09-05"), Location = "Tokyo, Japan", NumberTickets = 600, Price = 60.0f },
                    new Conference() { Id = 5, AuthorId = 6, Title = "AgileConf", Content = "A conference for agile practitioners", DateConference = DateTime.Parse("2024-10-20"), Location = "Sydney, Australia", NumberTickets = 400, Price = 40.0f },
                    new Conference() { Id = 6, AuthorId = 6, Title = "DataScienceSummit", Content = "A summit for data science professionals", DateConference = DateTime.Parse("2024-11-12"), Location = "Paris, France", NumberTickets = 700, Price = 70.0f },
                    new Conference() { Id = 7, AuthorId = 6, Title = "CloudExpo", Content = "An expo showcasing cloud technologies", DateConference = DateTime.Parse("2024-12-01"), Location = "Berlin, Germany", NumberTickets = 900, Price = 90.0f },
                    new Conference() { Id = 8, AuthorId = 7, Title = "AIConference", Content = "A conference exploring artificial intelligence", DateConference = DateTime.Parse("2025-01-18"), Location = "Moscow, Russia", NumberTickets = 1200, Price = 120.0f }
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
