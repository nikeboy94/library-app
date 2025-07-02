using LibraryApp.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Database.Migrations
{
    public static class SeedData
    {
        public static int SeedBooks(this LibContext context)
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

            return context.SaveChanges();
        }
    }
}
