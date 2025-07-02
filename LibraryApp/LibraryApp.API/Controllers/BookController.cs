using LibraryApp.Database.Repositories;
using LibraryApp.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("books")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookRepository _bookRepository;

        public BookController(ILogger<BookController> logger, IBookRepository bookRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
        }

        [HttpGet]
        [Route("all")]
        [ProducesResponseType(typeof(IEnumerable<BookDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBooks(int? skip = null, int? limit = null)
        {
            _logger.LogInformation("Request received to retrieve books");

            var books = await _bookRepository.GetBooks(skip, limit);

            return Ok(books);
        }
    }
}
