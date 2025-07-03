using LibraryApp.Database.Entities;

namespace LibraryApp.Database.Migrations
{
    public static class SeedData
    {
        public static int SeedBooks(this LibContext context)
        {
            int changes = 0;

            if (!context.Books.Any())
            {
                var books = new List<Book>()
                {
                    new Book()
                    {
                        Title = "Lord of the Rings",
                        Description = "Something about a ring",
                        Author = "J.R.R. Tolkien"
                    },
                    new Book()
                    {
                        Title = "Amazing Spider-Man #1",
                        Description = "About a friendly neighbourhood spider-man",
                        Author = "Stan Lee & Steve Ditko"
                    },
                };

                context.Books.AddRange(books);

                changes += context.SaveChanges();
            }

            return changes;
        }
    }
}
