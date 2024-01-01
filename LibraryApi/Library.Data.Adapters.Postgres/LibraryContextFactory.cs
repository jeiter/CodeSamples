using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Library.Data.Adapters.Postgres;

/// <summary>
/// Use for design time only
///
/// Run:
/// dotnet ef database update -- --connection "<connection-string>"
/// </summary>
public class LibraryContextFactory : IDesignTimeDbContextFactory<LibraryContext>
{
    public LibraryContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<LibraryContext>();
        optionsBuilder.UseNpgsql(args[1]);

        return new LibraryContext(optionsBuilder.Options);
    }
}