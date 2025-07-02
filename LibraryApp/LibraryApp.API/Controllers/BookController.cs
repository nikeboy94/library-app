using LibraryApp.Database.Repositories;
using LibraryApp.DataTransferObjects;
using Mapster;
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
        [Route("")]
        [ProducesResponseType(typeof(IEnumerable<BookDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBooks(int? skip = null, int? limit = null)
        {
            _logger.LogInformation("Request received to retrieve books");

            var books = await _bookRepository.GetBooks(skip, limit);

            return Ok(books);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(BookDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBook(int id)
        {
            _logger.LogInformation("Request received to retrieve books with Id {id}", id);

            var books = await _bookRepository.GetBook(id);

            return Ok(books);
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(BookDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddBook(BookPostDto book)
        {
            _logger.LogInformation("Request received to add book");

            var books = await _bookRepository.AddBook(book);

            return Ok(books);
        }

        [HttpPatch]
        [Route("{id}")]
        [ProducesResponseType(typeof(BookDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateBook(int id, BookUpdateDto book)
        {
            _logger.LogInformation("Request received to update book with Id {id}", id);

            var books = await _bookRepository.UpdateBook(id, book);

            return Ok(books);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(BookDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateBook(int id, BookPostDto book)
        {
            _logger.LogInformation("Request received to update book with Id {id}", id);

            var books = await _bookRepository.UpdateBook(id, book.Adapt<BookUpdateDto>());

            return Ok(books);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteBook(int id)
        {
            _logger.LogInformation("Request received to delete book with Id {id}", id);

            await _bookRepository.DeleteBook(id);

            return Ok();
        }
    }
}
