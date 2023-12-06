using AutoMapper;
using Library.Core.Application.Ports;
using Library.Core.Models;
using Library.Data.Adapters.Postgres.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.Adapters.Postgres.Adapters;

public class BooksAdapter : IBooksPort
{
    private readonly IMapper _mapper;
    private readonly LibraryContext _libraryContext;


    public BooksAdapter(IMapper mapper, LibraryContext libraryContext)
	{
        _mapper = mapper;
        _libraryContext = libraryContext;
	}

    /// <inheritdoc />
    public async Task<IEnumerable<Book>> GetBooksAsync(CancellationToken cancellationToken)
    {
        var books = await _libraryContext.Books
            .OrderBy(b => b.Title)
            .ToListAsync(cancellationToken);

        return _mapper.Map<IEnumerable<Book>>(books);
    }

    /// <inheritdoc />
    public async Task<Book> GetBookByIdAsync(string id, CancellationToken cancellationToken)
    {
        var book = await _libraryContext.Books
            .Where(b => b.Id == id)
            .FirstOrDefaultAsync(cancellationToken);

        return _mapper.Map<Book>(book);
    }

    /// <inheritdoc />
    public async Task<Book> AddBookAsync(Book book, CancellationToken cancellationToken)
    {
        var addedBook = await _libraryContext.Books.AddAsync(_mapper.Map<BookEntity>(book), cancellationToken);
        await _libraryContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<Book>(addedBook.Entity);
    }

    /// <inheritdoc />
    public async Task DeleteBookAsync(string id, CancellationToken cancellationToken)
    {
        var bookToDelete = await _libraryContext.Books.FirstAsync(b => b.Id == id, cancellationToken);

        _libraryContext.Remove(bookToDelete);
        await _libraryContext.SaveChangesAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<Book> UpdateBookAsync(string id, Book book, CancellationToken cancellationToken)
    {
        var bookToUpdate = await _libraryContext.Books.FirstAsync(b => b.Id == id, cancellationToken);

        // Update fields
        bookToUpdate.Title = book.Title;
        bookToUpdate.Summary = book.Summary;
        bookToUpdate.Author = book.Author;
        bookToUpdate.NumberOfPages = book.NumberOfPages;
        bookToUpdate.Publisher = book.Publisher;
        bookToUpdate.PublishedOn = book.PublishedOn;

        var updatedBook = _libraryContext.Update(bookToUpdate);
        await _libraryContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<Book>(updatedBook.Entity);
    }
}
