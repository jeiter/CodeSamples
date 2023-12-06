using Library.Core.Application.Commands;
using Library.Core.Application.Ports;
using Library.Core.Models;
using NSubstitute;

namespace Library.Core.Application.Tests;

public class UpdateBookCommandTest
{
    private readonly IBooksPort _bookAdapter;

    public UpdateBookCommandTest()
    {
        _bookAdapter = Substitute.For<IBooksPort>();
    }

    [Fact]
    public async void Handle_ValidCommand_UpdatesBookSuccessfully()
    {
        // Arrange
        var id = Guid.NewGuid().ToString();
        var book = new Book
        {
            Title = "Test",
            Summary = "Some Summary",
            Author = "John Doe"
        };
        var command = new UpdateBookCommand(id, book);
        var handler = new UpdateBookCommandHandler(_bookAdapter);

        // Act
        await handler.Handle(command, CancellationToken.None);

        // Assert
        await _bookAdapter.Received(1).UpdateBookAsync(id, book, CancellationToken.None);
    }
}
