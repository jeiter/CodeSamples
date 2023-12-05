using AutoMapper;
using Library.Core.Application.Ports;
using Library.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.Adapters.Sql.Adapters;

public class BooksAdapter : IBooksPort
{
    private LibraryContext _libraryContext;
    private IMapper _mapper;

	public BooksAdapter(LibraryContext libraryContext, IMapper mapper)
	{
        _mapper = mapper;
        _libraryContext = libraryContext;
	}

    /// <inheritdoc />
    public async Task<IEnumerable<Book>> GetBooks(CancellationToken cancellationToken)
    {
        var books = await _libraryContext.Books
            .OrderBy(b => b.Title)
            .ToListAsync();
         
        return _mapper.Map<IEnumerable<Book>>(books);
    }
}
