using LibraryApp.DataTransferObjects;

namespace LibraryApp.Database.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<BookDto>> GetBooks(int? skip = 0, int? limit = 0);
    }
}
