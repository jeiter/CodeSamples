using AutoMapper;
using Library.Api.Models;
using Library.Core.Application.Queries;
using MediatR;
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
    /// Get a list of books.
    /// </summary>
    /// <returns></returns>
    [HttpGet(Name = "GetBooks")]
    [Produces("application/json")]
    public async Task<IEnumerable<BookResponse>> GetAsync()
    {
        _logger.LogInformation("Get Books");

        var books = await _mediator.Send(new GetBooksQuery());

        return _mapper.Map<IEnumerable<BookResponse>>(books);
    }

    /// <summary>
    /// Get a book by id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}", Name = "GetBookById")]
    [Produces("application/json")]
    public async Task<BookResponse> GetByIdAsync([FromRoute]string id)
    {
        _logger.LogInformation("Get Books");

        var book = await _mediator.Send(new GetBookByIdQuery(id));

        return _mapper.Map<BookResponse>(book);
    }
}
