using Library.Core.Application.Ports;
using Library.Core.Models;
using MediatR;

namespace Library.Core.Application.Queries;

public record GetBookByIdQuery : IRequest<Book>
{
    public string Id { get; }

    public GetBookByIdQuery(string id)
    {
        Id = id;
    }
};

public class GetBookHandler : IRequestHandler<GetBookByIdQuery, Book>
{
    private readonly IBooksPort _booksAdapter;

    public GetBookHandler(IBooksPort booksAdapter)
    {
        _booksAdapter = booksAdapter;
    }

    public async Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        return await _booksAdapter.GetBookById(request.Id,cancellationToken);
    }
}
