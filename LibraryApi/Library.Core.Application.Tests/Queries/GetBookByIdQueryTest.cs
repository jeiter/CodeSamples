using Library.Core.Application.Ports;
using Library.Core.Application.Queries;
using NSubstitute;

namespace Library.Core.Application.Tests.Queries;

public class GetBookByIdQueryTest
{
    private readonly IBooksPort _bookAdapter;

    public GetBookByIdQueryTest()
    {
        _bookAdapter = Substitute.For<IBooksPort>();
    }

    [Fact]
    public async void Handle_ValidQuery_GetsBookByIdSuccessfully()
    {
        // Arrange
        var id = Guid.NewGuid().ToString();
      
        var query = new GetBookByIdQuery(id);
        var handler = new GetBookByIdHandler(_bookAdapter);

        // Act
        await handler.Handle(query, CancellationToken.None);

        // Assert
        await _bookAdapter.Received(1).GetBookByIdAsync(id, CancellationToken.None);
    }
}