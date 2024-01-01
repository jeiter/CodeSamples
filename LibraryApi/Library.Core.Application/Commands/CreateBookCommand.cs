using Library.Core.Application.Ports;
using Library.Core.Models;
using MediatR;

namespace Library.Core.Application.Commands;

public record CreateBookCommand(Book Book) : IRequest<Book>;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Book>
{
    private readonly IBooksPort _booksAdapter;

    public CreateBookCommandHandler(IBooksPort booksAdapter)
    {
        _booksAdapter = booksAdapter;
    }

    public async Task<Book> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        return await _booksAdapter.AddBookAsync(request.Book, cancellationToken);
    }
}