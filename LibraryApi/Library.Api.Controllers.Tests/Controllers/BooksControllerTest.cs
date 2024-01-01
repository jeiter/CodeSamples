using AutoMapper;
using FluentAssertions;
using Library.Api.Controllers.Controllers.Models;
using Library.Api.Models;
using Library.Core.Application.Commands;
using Library.Core.Application.Queries;
using Library.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace Library.Api.Controllers.Tests;

public class BooksControllerTest
{
    private readonly BooksController _controller;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ILogger<BooksController> _logger;

    private BookRequest _bookRequest;
    private Book _book;
    private BookResponse _bookResponse;

    public BooksControllerTest()
    {
        _mediator = Substitute.For<IMediator>();
        _mapper = Substitute.For<IMapper>();
        _logger = Substitute.For<ILogger<BooksController>>();

        _controller = new BooksController(_mediator, _mapper, _logger);

        _bookRequest = new BookRequest
        {
            Title = "Test Book",
            Summary = "Just a summary",
            Author = "John Doe",
            NumberOfPages = 500,
            Publisher = "Joan Doe",
            PublishedOn = DateTime.Parse("2023-12-06")
        };
        _book = new Book
        {
            Id = "validId",
            Title = "Test Book",
            Summary = "Just a summary",
            Author = "John Doe",
            NumberOfPages = 500,
            Publisher = "Joan Doe",
            PublishedOn = DateTime.Parse("2023-12-06")
        };
        _bookResponse = new BookResponse
        {
            Id = "validId",
            Title = "Test Book",
            Summary = "Just a summary",
            Author = "John Doe",
            NumberOfPages = 500,
            Publisher = "Joan Doe",
            PublishedOn = DateTime.Parse("2023-12-06")
        };
    }

    [Fact]
    public async Task PostAsync_ValidBookRequest_ReturnsCreatedResponse()
    {
        // Arrange
        _mediator.Send(Arg.Any<CreateBookCommand>()).Returns(Task.FromResult(_book));
        _mapper.Map<Book>(Arg.Any<BookRequest>()).Returns(_book);
        _mapper.Map<BookResponse>(Arg.Any<Book>()).Returns(_bookResponse);

        // Act
        var result = await _controller.PostAsync(_bookRequest);

        // Assert
        result.Should().BeOfType<ActionResult<BookResponse>>();
        result.Result.Should().NotBeNull();
        result.Result.Should().BeOfType<CreatedAtRouteResult>();

        var createdResult = result.Result as CreatedAtRouteResult;
        createdResult?.Value.Should().NotBeNull();
        createdResult?.Value.Should().BeOfType<BookResponse>();
    }

    [Fact]
    public async Task GetByIdAsync_ValidId_ReturnsOkResponse()
    {
        // Arrange
        _mediator.Send(Arg.Any<GetBookByIdQuery>()).Returns(Task.FromResult(_book));
        _mapper.Map<BookResponse>(Arg.Any<Book>()).Returns(_bookResponse);

        // Act
        var result = await _controller.GetByIdAsync(_book.Id);

        // Assert
        result.Should().BeOfType<ActionResult<BookResponse>>();
        result.Result.Should().NotBeNull();
        result.Result.Should().BeOfType<OkObjectResult>();

        var okResult = result.Result as OkObjectResult;
        okResult?.Value.Should().NotBeNull();
        okResult?.Value.Should().BeOfType<BookResponse>();
    }
   

    [Fact]
    public async Task DeleteByIdAsync_ValidId_ReturnsNoContentResponse()
    {
        // Arrange
        var bookId = "validId";

        // Act
        var result = await _controller.DeleteByIdAsync(bookId);

        // Assert
        result.Should().BeOfType<NoContentResult>();
    }
}
