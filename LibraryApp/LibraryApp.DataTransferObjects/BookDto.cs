﻿namespace LibraryApp.DataTransferObjects
{
    public class BookDto
    {
        public required int Id { get; set; }

        public required string Title { get; set; }

        public string? Description { get; set; }

        public required string Author { get; set; }
    }
}
