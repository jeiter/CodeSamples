using Library.Core.Models;

namespace Library.Core.Application.Ports;

public interface IBooksPort
{
    /// <summary>
    /// Gets list of books
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<Book>> GetBooks(CancellationToken cancellationToken);

    /// <summary>
    /// Gets a book by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Book> GetBookById(string id, CancellationToken cancellationToken);
}
