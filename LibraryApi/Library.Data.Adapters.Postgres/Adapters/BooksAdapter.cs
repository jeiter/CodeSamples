﻿using AutoMapper;
using Library.Core.Application.Ports;
using Library.Core.Models;
using Library.Data.Adapters.Postgres.Models;
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
    public async Task<IEnumerable<Book>> GetBooksAsync(CancellationToken cancellationToken)
    {
        _logger.LogDebug("Method 'GetBooksAsync' started");

        var books = await _libraryContext.Books
            .OrderBy(b => b.Title)
            .ToListAsync(cancellationToken);

        _logger.LogDebug("Method 'GetBooksAsync' finished");

        return _mapper.Map<IEnumerable<Book>>(books);
    }

    /// <inheritdoc />
    public async Task<Book> GetBookByIdAsync(string id, CancellationToken cancellationToken)
    {
        _logger.LogDebug("Method 'GetBookByIdAsync' started");

        var book = await _libraryContext.Books
            .Where(b => b.Id == id)
            .FirstOrDefaultAsync(cancellationToken);

        _logger.LogDebug("Method 'GetBookByIdAsync' finished");

        return _mapper.Map<Book>(book);
    }

    /// <inheritdoc />
    public async Task<Book> AddBookAsync(Book book, CancellationToken cancellationToken)
    {
        _logger.LogDebug("Method 'AddBookAsync' started");

        var addedBook = await _libraryContext.Books.AddAsync(_mapper.Map<BookEntity>(book), cancellationToken);

        await _libraryContext.SaveChangesAsync(cancellationToken);

        _logger.LogDebug("Method 'AddBookAsync' finished");

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
