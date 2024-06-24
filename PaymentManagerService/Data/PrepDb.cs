using PaymentManagerService.Models;

namespace PaymentManagerService.Data
{
    public class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<PaymentManagerDbContext>();
                if (context == null)
                {
                    throw new Exception("Null PaymentManagerDbContext");
                }
                SeedData(context);
            }
        }

        private static void SeedData(PaymentManagerDbContext context)
        {
            if(context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (!context.Payments.Any())
            {
                Console.WriteLine("--> Seeding data...");
                // Seed data Payment
                context.Payments.AddRange(
                    new Payment
                    {
                        Id = 1,
                        Amount = "100",
                        Currency = "USD",
                        CardNumber = 2345678901323412,
                        CardCVV = 123,
                        CardExpirationDate = "12/23",
                        UserId = 1
                    },
                    new Payment
                    {
                        Id = 2,
                        Amount = "200",
                        Currency = "USD",
                        CardNumber = 2345678901323412,
                        CardCVV = 234,
                        CardExpirationDate = "12/24",
                        UserId = 2
                    },
                    new Payment
                    {
                        Id = 3,
                        Amount = "300",
                        Currency = "USD",
                        CardNumber = 2345678901323412,
                        CardCVV = 345,
                        CardExpirationDate = "12/25",
                        UserId = 3
                    },
                    new Payment
                    {
                        Id = 4,
                        Amount = "400",
                        Currency = "USD",
                        CardNumber = 2345678901323412,
                        CardCVV = 456,
                        CardExpirationDate = "12/26",
                        UserId = 4
                    }
                );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> Data already exists");
            }
        }
    }
}
