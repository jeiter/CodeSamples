using AutoMapper;
using Library.Api.Controllers.Controllers.Models;
using Library.Api.Models;
using Library.Core.Application.Commands;
using Library.Core.Application.Queries;
using Library.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Library.Api.Controllers;


[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ILogger<BooksController> _logger;

    public BooksController(IMediator mediator, IMapper mapper, ILogger<BooksController> logger)
    {
        _mediator = mediator;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// Create a new book.
    /// </summary>
    /// <param name="bookRequest"></param>
    /// <returns></returns>
    [HttpPost(Name = "PostBook")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BookResponse>> PostAsync([FromBody] BookRequest bookRequest)
    {
        _logger.LogInformation("Create book");

        var book = await _mediator.Send(new CreateBookCommand(_mapper.Map<Book>(bookRequest)));

        return CreatedAtRoute("GetBookById", new { id = book.Id }, _mapper.Map<BookResponse>(book));
    }

    /// <summary>
    /// Get a book by id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPut("{id}", Name = "GetBookById")]
    [Produces("application/json")]
    public async Task<ActionResult<BookResponse>> GetByIdAsync([FromRoute] string id, [FromBody] BookRequest bookRequest)
    {
        _logger.LogInformation("Get book by id");

        var book = await _mediator.Send(new UpdateBookCommand(id, _mapper.Map<Book>(bookRequest)));

        return Ok(_mapper.Map<BookResponse>(book));
    }

    /// <summary>
    /// Get a list of books.
    /// </summary>
    /// <returns></returns>
    [HttpGet(Name = "GetBooks")]
    [Produces("application/json")]
    public async Task<ActionResult<IEnumerable<BookResponse>>> GetAsync()
    {
        _logger.LogInformation("Get books");

        var books = await _mediator.Send(new GetBooksQuery());

        return Ok(_mapper.Map<IEnumerable<BookResponse>>(books));
    }

    /// <summary>
    /// Get a book by id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}", Name = "GetBookById")]
    [Produces("application/json")]
    public async Task<ActionResult<BookResponse>> GetByIdAsync([FromRoute] string id)
    {
        _logger.LogInformation("Get book by id");

        var book = await _mediator.Send(new GetBookByIdQuery(id));

        return Ok(_mapper.Map<BookResponse>(book));
    }

    /// <summary>
    /// Delete a book by id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}", Name = "DeleteBookById")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteByIdAsync([FromRoute] string id)
    {
        _logger.LogInformation("Delete book by id");

        await _mediator.Send(new DeleteBookCommand(id));

        return NoContent();
    }
}
