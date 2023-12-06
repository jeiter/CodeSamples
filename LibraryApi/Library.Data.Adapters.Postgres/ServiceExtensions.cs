using Library.Core.Application.Ports;
using Library.Data.Adapters.Postgres.Adapters;
using Library.Data.Adapters.Postgres.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Data.Adapters.Postgres;

public static class ServiceExtensions
{
    public static IServiceCollection AddPostgresDataServices(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<LibraryContext>(options => options.UseNpgsql(connectionString));

        services.AddTransient<IBooksPort, BooksAdapter>();

        services.AddAutoMapper(typeof(MappingProfile));

        return services;
    }
}
