using Library.Core.Application.Ports;
using Library.Core.Application.Queries;
using NSubstitute;

namespace Library.Core.Application.Tests.Queries;

public class GetBooksQueryTest
{
    private readonly IBooksPort _bookAdapter;

    public GetBooksQueryTest()
    {
        _bookAdapter = Substitute.For<IBooksPort>();
    }

    [Fact]
    public async void Handle_ValidQuery_GetsBooksSuccessfully()
    {
        // Arrange
        var id = Guid.NewGuid().ToString();

        var query = new GetBooksQuery();
        var handler = new GetBooksHandler(_bookAdapter);

        // Act
        await handler.Handle(query, CancellationToken.None);

        // Assert
        await _bookAdapter.Received(1).GetBooksAsync(CancellationToken.None);
    }
}