using Library.Api.Controllers.Mapping;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;
using Microsoft.OpenApi.Models;

namespace Library.Api.Controllers;

public static class ServiceExtensions
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddAutoMapper(typeof(MappingProfile));

        services.Configure<ApiBehaviorOptions>(options
            => options.SuppressModelStateInvalidFilter = false);

        services.AddControllers();
        services.AddEndpointsApiExplorer();

        services.AddApiVersioning(options =>
        {
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);
        });

        services.AddFeatureManagement(config.GetSection("FeatureFlags"));

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Library API",
                Description = "The Library API is a straightforward tool for managing books, patrons, and transactions in library systems. It offers easy integration, simplifying tasks like searching, borrowing, and returning books.",
                Version = "1.0"
            });
        });

        return services;
    }
}
