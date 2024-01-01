using System.ComponentModel.DataAnnotations;

namespace Library.Api.Controllers.Controllers.Models;

public class BookRequest
{
    [Required]
    public string Title { get; set; }

    public string? Summary { get; set; }

    [Required]
    public int NumberOfPages { get; set; }

    [Required]
    public string Author { get; set; }

    [Required]
    public string Publisher { get; set; }

    [Required]
    public DateTime PublishedOn { get; set; }
}
