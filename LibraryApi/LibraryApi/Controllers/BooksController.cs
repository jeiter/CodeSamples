using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{

    private readonly ILogger<BooksController> _logger;

    public BooksController(ILogger<BooksController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetBooks")]
    public IEnumerable<Book> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new Book
        {
            Title = "This is a Book",
            Author = "John Doe",
            Summary = "This is just a book summary",
            Publisher = "Fred Publisher",
            NumberOfPages = 215,
            PublishedOn = DateTime.Now.AddDays(index),
        })
        .ToArray();
    }
}

