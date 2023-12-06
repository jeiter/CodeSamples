using Library.Core.Application.Ports;
using Library.Core.Models;
using MediatR;

namespace Library.Core.Application.Queries;

public record GetBookByIdQuery(string Id) : IRequest<Book>;

public class GetBookHandler : IRequestHandler<GetBookByIdQuery, Book>
{
    private readonly IBooksPort _booksAdapter;

    public GetBookHandler(IBooksPort booksAdapter)
    {
        _booksAdapter = booksAdapter;
    }

    public async Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        return await _booksAdapter.GetBookByIdAsync(request.Id,cancellationToken);
    }
}
