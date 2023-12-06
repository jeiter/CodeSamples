using Library.Core.Application.Commands;
using Library.Core.Application.Ports;
using NSubstitute;

namespace Library.Core.Application.Tests;

public class DeleteBookCommandTest
{
    private readonly IBooksPort _bookAdapter;

    public DeleteBookCommandTest()
    {
        _bookAdapter = Substitute.For<IBooksPort>();
    }

    [Fact]
    public async void Handle_ValidCommand_DeletesBookSuccessfully()
    {
        // Arrange
        var id = Guid.NewGuid().ToString();
        var command = new DeleteBookCommand(id);
        var handler = new DeleteBookCommandHandler(_bookAdapter);

        // Act
        await handler.Handle(command, CancellationToken.None);

        // Assert
        await _bookAdapter.Received(1).DeleteBookAsync(id, CancellationToken.None);
    }
}
