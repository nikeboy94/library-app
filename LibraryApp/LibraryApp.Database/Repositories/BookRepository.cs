using LibraryApp.Database.Entities;
using LibraryApp.DataTransferObjects;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            using (var context = _dbContextFactory.CreateDbContext())
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
    }
}
