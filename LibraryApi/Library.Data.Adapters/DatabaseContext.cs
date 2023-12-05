using Library.Data.Adapters.Sql.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.Adapters.Sql;

public class LibraryContext : DbContext
{
    public DbSet<BookEntity> Books { get; set; }

    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=library;Username=library_api;Password=S0mePassw0rd");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookEntity>().ToTable("Books");

        modelBuilder.Entity<BookEntity>()
            .HasKey(b => b.Id);

        base.OnModelCreating(modelBuilder);
    }
}
