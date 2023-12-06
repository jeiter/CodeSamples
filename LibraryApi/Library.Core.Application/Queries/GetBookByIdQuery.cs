using Library.Core.Application.Ports;
using Library.Core.Models;
using MediatR;

namespace Library.Core.Application.Queries;

public record GetBookByIdQuery(string Id) : IRequest<Book>;

public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, Book>
{
    private readonly IBooksPort _booksAdapter;

    public GetBookByIdHandler(IBooksPort booksAdapter)
    {
        _booksAdapter = booksAdapter;
    }

    public async Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        return await _booksAdapter.GetBookByIdAsync(request.Id,cancellationToken);
    }
}
