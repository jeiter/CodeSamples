using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Library.Core.Models;
using Library.Data.Adapters.Postgres.Adapters;
using Library.Data.Adapters.Postgres.Mapping;
using Library.Data.Adapters.Postgres.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.Adapters.Postgres.Tests.Adapters;

public class BooksAdapterTest
{
    private readonly IMapper _mapper;

    public BooksAdapterTest()
    {
        var config = new MapperConfiguration(c => c.AddProfile<MappingProfile>());
        _mapper = new Mapper(config);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(2)]
    public async void GetBooksAsync_ReturnsBooks(int numberOfBooks)
    {
        // Arrange
        var mockDbContext = CreateDbContext();
        await SeedDatabase(mockDbContext, numberOfBooks);

        var booksAdapter = new BooksAdapter(_mapper, mockDbContext);

        // Act
        var result = await booksAdapter.GetBooksAsync(CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Count().Should().Be(numberOfBooks);
    }

    [Fact]
    public async void GetBookByIdAsync_ReturnsBook()
    {
        // Arrange
        var mockDbContext = CreateDbContext();
        var createdBooks = await SeedDatabase(mockDbContext, 1);

        var book = createdBooks.First();

        var booksAdapter = new BooksAdapter(_mapper, mockDbContext);

        // Act
        var result = await booksAdapter.GetBookByIdAsync(book.Id, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Title.Should().Be(book.Title);
        result.Summary.Should().Be(book.Summary);
        result.Author.Should().Be(book.Author);
        result.NumberOfPages.Should().Be(book.NumberOfPages);
        result.Publisher.Should().Be(book.Publisher);
        result.PublishedOn.Should().Be(book.PublishedOn);
    }

    [Fact]
    public async void AddBookAsync_ReturnsCreatedBook()
    {
        // Arrange
        var book = new Book
        {
            Title = "Test Book",
            Summary = "Just a summary",
            Author = "John Doe",
            NumberOfPages = 500,
            Publisher = "Joan Doe",
            PublishedOn = DateTime.Parse("2023-12-06")
        };
        var mockDbContext = CreateDbContext();
        var booksAdapter = new BooksAdapter(_mapper, mockDbContext);

        // Act
        var result = await booksAdapter.AddBookAsync(book, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Title.Should().Be(book.Title);
        result.Summary.Should().Be(book.Summary);
        result.Author.Should().Be(book.Author);
        result.NumberOfPages.Should().Be(book.NumberOfPages);
        result.Publisher.Should().Be(book.Publisher);
        result.PublishedOn.Should().Be(book.PublishedOn);
    }

    [Fact]
    public async void UpdateBookAsync_ReturnsUpdatedBook()
    {
        // Arrange
        var mockDbContext = CreateDbContext();
        var createdBooks = await SeedDatabase(mockDbContext, 1);

        var bookToUpdate = _mapper.Map<Book>(createdBooks.First());
        bookToUpdate.Author = "Joan Doe";

        var booksAdapter = new BooksAdapter(_mapper, mockDbContext);

        // Act
        var result = await booksAdapter.UpdateBookAsync(bookToUpdate.Id, bookToUpdate, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Author.Should()
            .Be(bookToUpdate.Author);
    }

    [Fact]
    public async void DeleteBookAsync_RemovesBookFromDbContext()
    {
        // Arrange
        var mockDbContext = CreateDbContext();
        var createdBooks = await SeedDatabase(mockDbContext, 1);

        var bookToDelete = createdBooks.First();

        var booksAdapter = new BooksAdapter(_mapper, mockDbContext);

        // Act
        await booksAdapter.DeleteBookAsync(bookToDelete.Id, CancellationToken.None);

        // Assert
        var book = await mockDbContext.Books
            .Where(b => b.Id == bookToDelete.Id)
            .FirstOrDefaultAsync();
        book.Should()
            .BeNull();
    }

    #region Database helper
    private LibraryContext CreateDbContext()
    {
        var options = new DbContextOptionsBuilder<LibraryContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        return new LibraryContext(options);
    }

    private async Task<List<BookEntity>> SeedDatabase(DbContext mockDbContext, int numberOfBooks)
    {
        var fixture = new Fixture();
        var bookEntities = new List<BookEntity>();

        for (int i = 0; i < numberOfBooks; i++)
        {
            bookEntities.Add(fixture.Create<BookEntity>());
        }

        await mockDbContext.AddRangeAsync(bookEntities);
        await mockDbContext.SaveChangesAsync();
        return bookEntities;
    }
    #endregion Database helper
}