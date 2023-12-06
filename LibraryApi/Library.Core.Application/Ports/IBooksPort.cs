using Library.Core.Models;

namespace Library.Core.Application.Ports;

public interface IBooksPort
{
    /// <summary>
    /// Gets list of books
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<Book>> GetBooksAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Gets a book by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Book> GetBookByIdAsync(string id, CancellationToken cancellationToken);

    /// <summary>
    /// Adds a book
    /// </summary>
    /// <param name="book"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Book> AddBookAsync(Book book, CancellationToken cancellationToken);

    /// <summary>
    /// Deletes a book
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeleteBookAsync(string id, CancellationToken cancellationToken);
}
