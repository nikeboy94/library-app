using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Database.Migrations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running database migrations...");

            using (var context = new LibContextFactory().CreateDbContext(args))
            {
                context.Database.Migrate();

                context.SeedBooks();
            }
        }
    }
}
