using Library.Core.Application.Ports;
using MediatR;

namespace Library.Core.Application.Commands;

public record DeleteBookCommand(string Id) : IRequest;

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
{
    private readonly IBooksPort _booksAdapter;

    public DeleteBookCommandHandler(IBooksPort booksAdapter)
    {
        _booksAdapter = booksAdapter;
    }

    public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        await _booksAdapter.DeleteBookAsync(request.Id, cancellationToken);
    }
}
