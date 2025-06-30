using System.ComponentModel.DataAnnotations;

namespace LibraryApp.API.Models
{
    public class BookModel
    {
        public required string Title { get; set; }

        public string? Description { get; set; }

        public required string Author { get; set; }
    }
}
