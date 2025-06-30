using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Database.Entities
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public required string Title { get; set; }

        public string? Description { get; set; }

        [Required]
        public required string Author { get; set; }
    }
}
