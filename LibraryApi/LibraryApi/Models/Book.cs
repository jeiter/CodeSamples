namespace Library.Api.Models;

public class Book
{
    public string Title { get; set; }

    public string? Summary { get; set; }

    public int NumberOfPages { get; set; }

    public string Author { get; set; }

    public string Publisher { get; set; }

    public DateTime PublishedOn { get; set; }
}
