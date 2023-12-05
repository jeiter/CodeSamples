using AutoMapper;
using Library.Api.Models;
using Library.Core.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers;


[ApiController]
[Route("[controller]")]
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

    [HttpGet(Name = "GetBooks")]
    public async Task<IEnumerable<BookResponse>> GetAsync()
    {
        _logger.LogInformation("Get Books");

        var books = await _mediator.Send(new GetBooksQuery());

        return _mapper.Map<IEnumerable<Models.BookResponse>>(books);
    }
}
