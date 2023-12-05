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
}
