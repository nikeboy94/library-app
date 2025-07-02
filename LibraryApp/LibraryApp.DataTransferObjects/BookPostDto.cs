namespace LibraryApp.DataTransferObjects
{
    public class BookPostDto
    {
        public required string Title { get; set; }

        public string? Description { get; set; }

        public required string Author { get; set; }
    }
}
