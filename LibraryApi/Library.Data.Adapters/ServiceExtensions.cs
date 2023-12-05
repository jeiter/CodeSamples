using Library.Core.Application.Ports;
using Library.Data.Adapters.Sql.Adapters;
using Library.Data.Adapters.Sql.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Data.Adapters;

public static class ServiceExtensions
{
    public static IServiceCollection AddSqlDataServices(this IServiceCollection services)
    {
        services.AddTransient<IBooksPort, BooksAdapter>();

        services.AddAutoMapper(typeof(MappingProfile));

        return services;
    }
}
