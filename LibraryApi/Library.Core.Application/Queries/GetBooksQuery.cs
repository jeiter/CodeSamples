using Library.Core.Models;
using MediatR;

namespace Library.Core.Application.Queries
{
    public record GetBooksQuery() : IRequest<IEnumerable<Book>>;

    public class GetBooksHandler : IRequestHandler<GetBooksQuery, IEnumerable<Book>>
    {
      
        public async Task<IEnumerable<Book>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var task = Task.Run(() => Enumerable.Range(1, 5).Select(index => new Book
            {
                Title = "This is a Book",
                Author = "John Doe",
                Summary = "This is just a book summary",
                Publisher = "Fred Publisher",
                NumberOfPages = 215,
                PublishedOn = DateTime.Now.AddDays(index),
            })
            .ToArray());

            return await task;
        }
    }
}
