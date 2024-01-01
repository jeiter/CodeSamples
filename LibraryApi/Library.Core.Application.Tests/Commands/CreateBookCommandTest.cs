using Library.Core.Application.Commands;
using Library.Core.Application.Ports;
using Library.Core.Models;
using NSubstitute;

namespace Library.Core.Application.Tests;

public class CreateBookCommandTest
{
    private readonly IBooksPort _bookAdapter;

    public CreateBookCommandTest()
    {
        _bookAdapter = Substitute.For<IBooksPort>();
    }

    [Fact]
    public async void Handle_ValidCommand_CreatesBookSuccessfully()
    {
        // Arrange
        var book = new Book
        {
            Title = "Test",
            Summary = "Some Summary",
            Author = "John Doe"
        };
        var command = new CreateBookCommand(book);
        var handler = new CreateBookCommandHandler(_bookAdapter);

        // Act
        await handler.Handle(command, CancellationToken.None);

        // Assert
        await _bookAdapter.Received(1).AddBookAsync(book, CancellationToken.None);
    }
}
