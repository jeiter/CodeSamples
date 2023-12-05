using Library.Core.Application.Ports;
using Library.Data.Adapters.Sql;
using Library.Data.Adapters.Sql.Adapters;
using Library.Data.Adapters.Sql.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Data.Adapters;

public static class ServiceExtensions
{
    public static IServiceCollection AddSqlDataServices(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<LibraryContext>(options => options.UseNpgsql(connectionString));

        services.AddTransient<IBooksPort, BooksAdapter>();

        services.AddAutoMapper(typeof(MappingProfile));

        return services;
    }
}
