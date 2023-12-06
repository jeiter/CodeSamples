using AutoMapper;
using Library.Core.Application.Ports;
using Library.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Library.Data.Adapters.Postgres.Adapters;

public class BooksAdapter : IBooksPort
{
    private readonly IMapper _mapper;
    private readonly LibraryContext _libraryContext;
    private readonly ILogger<BooksAdapter> _logger;


    public BooksAdapter(IMapper mapper, LibraryContext libraryContext, ILogger<BooksAdapter> logger)
	{
        _mapper = mapper;
        _libraryContext = libraryContext;
        _logger = logger;
	}

    /// <inheritdoc />
    public async Task<IEnumerable<Book>> GetBooks(CancellationToken cancellationToken)
    {
        _logger.LogDebug("Method 'GetBooks' started");

        var books = await _libraryContext.Books
            .OrderBy(b => b.Title)
            .ToListAsync(cancellationToken);

        _logger.LogDebug("Method 'GetBooks' finished");

        return _mapper.Map<IEnumerable<Book>>(books);
    }

    /// <inheritdoc />
    public async Task<Book> GetBookById(string id, CancellationToken cancellationToken)
    {
        _logger.LogDebug("Method 'GetBookById' started");

        var book = await _libraryContext.Books
            .Where(b => b.Id == id)
            .FirstOrDefaultAsync(cancellationToken);

        _logger.LogDebug("Method 'GetBooks' finished");

        return _mapper.Map<Book>(book);
    }
}
