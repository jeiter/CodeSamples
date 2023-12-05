using Library.Core.Application.Ports;
using Library.Core.Models;
using MediatR;

namespace Library.Core.Application.Queries
{
    public record GetBooksQuery() : IRequest<IEnumerable<Book>>;

    public class GetBooksHandler : IRequestHandler<GetBooksQuery, IEnumerable<Book>>
    {
        private readonly IBooksPort _booksAdapter;

        public GetBooksHandler(IBooksPort booksAdapter)
        {
            _booksAdapter = booksAdapter;
        }
      
        public async Task<IEnumerable<Book>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            return await _booksAdapter.GetBooks(cancellationToken);
        }
    }
}
