using LibraryApp.DataTransferObjects;

namespace LibraryApp.Database.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<BookDto>> GetBooks(int? skip = 0, int? limit = 0);

        Task<BookDto> GetBook(int id);

        Task<BookDto> AddBook(BookPostDto book);

        Task<BookDto> UpdateBook(int id, BookUpdateDto book);

        Task<int> DeleteBook(int id);
    }
}
