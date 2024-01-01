using Library.Data.Adapters.Postgres.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.Adapters.Postgres;

public class LibraryContext : DbContext
{
    public DbSet<BookEntity> Books { get; set; }

    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookEntity>().ToTable("Books");

        modelBuilder.Entity<BookEntity>()
            .HasKey(b => b.Id);

        base.OnModelCreating(modelBuilder);
    }
}
