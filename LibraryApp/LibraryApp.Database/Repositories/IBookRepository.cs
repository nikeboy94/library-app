using LibraryApp.DataTransferObjects;

namespace LibraryApp.Database.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<BookDto>> GetBooks(int? skip = 0, int? limit = 0);

        Task<BookDto> GetBook(int id);

        Task<BookDto> AddBook(BookBaseDto book);

        Task<BookDto> UpdateBook(int id, BookBaseDto book);

        Task<int> DeleteBook(int id);
    }
}
