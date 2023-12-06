﻿using Library.Core.Application.Ports;
using Library.Core.Models;
using MediatR;

namespace Library.Core.Application.Commands;

public record AddBookCommand(Book Book) : IRequest<Book>;

public class AddBookCommandHandler : IRequestHandler<AddBookCommand, Book>
{
    private readonly IBooksPort _booksAdapter;

    public AddBookCommandHandler(IBooksPort booksAdapter)
    {
        _booksAdapter = booksAdapter;
    }

    public async Task<Book> Handle(AddBookCommand request, CancellationToken cancellationToken)
    {
        return await _booksAdapter.AddBookAsync(request.Book, cancellationToken);
    }
}