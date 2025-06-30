using LibraryApp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("books")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;

        public BookController(ILogger<BookController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetBooks()
        {
            var books = new List<BookModel>()
            {
                new BookModel()
                {
                    Title = "Lord of the Rings",
                    Description = "Something about a ring",
                    Author = "J.R.R. Tolkien"
                }
            };

            return Ok(books);
        }
    }
}
