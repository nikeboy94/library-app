using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Database.Migrations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new LibContextFactory().CreateDbContext(args))
            {
                Console.WriteLine("Running database migrations...");
                context.Database.Migrate();

                Console.WriteLine("Seeding data...");
                context.SeedBooks();
            }
        }
    }
}
