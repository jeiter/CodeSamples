using Library.Core.Application.Ports;
using Library.Core.Models;

namespace Library.Data.Adapters.Sql.Adapters;

public class BooksAdapter : IBooksPort
{
	public BooksAdapter()
	{
	}

    /// <inheritdoc />
    public async Task<IEnumerable<Book>> GetBooks(CancellationToken cancellationToken)
    {
        var task = Task.Run(() => Enumerable.Range(1, 5).Select(index => new Book
        {
            Title = "This is a Book",
            Author = "John Doe",
            Summary = "This is just a book summary",
            Publisher = "Fred Publisher",
            NumberOfPages = 215,
            PublishedOn = DateTime.Now.AddDays(index),
        }).ToArray());

        return await task;
    }
}
