using Library.Core.Application.Ports;
using Library.Core.Models;
using MediatR;

namespace Library.Core.Application.Commands;

public record UpdateBookCommand(string Id, Book Book) : IRequest<Book>;

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Book>
{
    private readonly IBooksPort _booksAdapter;

    public UpdateBookCommandHandler(IBooksPort booksAdapter)
    {
        _booksAdapter = booksAdapter;
    }

    public async Task<Book> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        return await _booksAdapter.UpdateBookAsync(request.Id, request.Book, cancellationToken);
    }
}