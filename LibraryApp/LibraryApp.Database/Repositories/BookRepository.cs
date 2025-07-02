using LibraryApp.Database.Entities;
using LibraryApp.DataTransferObjects;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LibraryApp.Database.Repositories
{
    public class BookRepository : IBookRepository
    {
        private ILogger<BookRepository> _logger;
        private IDbContextFactory<LibContext> _dbContextFactory;

        public BookRepository(ILogger<BookRepository> logger, IDbContextFactory<LibContext> dbContextFactory)
        {
            _logger = logger;
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<BookDto>> GetBooks(int? skip = 0, int? limit = 0)
        {
            _logger.LogInformation("Getting books...");

            using (var context = await _dbContextFactory.CreateDbContextAsync())
            {
                var booksQuery = context.Books.AsQueryable();

                if (skip.HasValue)
                {
                    booksQuery = booksQuery.Skip(skip.Value);
                }

                if (limit.HasValue)
                {
                    booksQuery = booksQuery.Take(limit.Value);
                }

                var books = await booksQuery.ToListAsync();

                return books.Select(b => b.Adapt<BookDto>()).ToList();
            }
        }

        public async Task<BookDto> GetBook(int id)
        {
            using (var context = await _dbContextFactory.CreateDbContextAsync())
            {
                var book = await context.Books
                    .Where(b => b.Id == id)
                    .SingleOrDefaultAsync();

                if (book == null)
                {
                    var msg = $"Book with Id {id} does not exist";
                    _logger.LogError(msg);
                    throw new InvalidOperationException(msg);
                }

                return book.Adapt<BookDto>();
            }
        }

        public async Task<BookDto> AddBook(BookBaseDto book)
        {
            using (var context = await _dbContextFactory.CreateDbContextAsync())
            {
                var bookEntity = book.Adapt<Book>();

                await context.Books.AddAsync(bookEntity);
                await context.SaveChangesAsync();

                return bookEntity.Adapt<BookDto>();
            }
        }

        public async Task<BookDto> UpdateBook(int id, BookBaseDto book)
        {
            using (var context = await _dbContextFactory.CreateDbContextAsync())
            {
                var bookEntity = await GetBook(id);

                bookEntity.Title = book.Title;
                bookEntity.Description = book.Description;
                bookEntity.Author = book.Author;

                await context.SaveChangesAsync();

                return bookEntity.Adapt<BookDto>();
            }
        }

        public async Task<int> DeleteBook(int id)
        {
            using (var context = await _dbContextFactory.CreateDbContextAsync())
            {
                var bookEntity = await context.Books
                    .Where(b => b.Id == id)
                    .SingleOrDefaultAsync();

                if (bookEntity == null)
                {
                    _logger.LogInformation("Book with Id {id} has already been deleted or does not exist", id);
                    return 0;
                }

                context.Remove(bookEntity);

                return await context.SaveChangesAsync();
            }
        }
    }
}
