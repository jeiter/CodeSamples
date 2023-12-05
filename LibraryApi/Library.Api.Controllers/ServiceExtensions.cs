﻿using Library.Api.Controllers.Mapping;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Library.Api.Controllers;

public static class ServiceExtensions
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile));

        services.AddControllers();
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Library API",
                Description = "The Library API is a straightforward tool for managing books, patrons, and transactions in library systems. It offers easy integration, simplifying tasks like searching, borrowing, and returning books.",
                Version = "v1"
            });
        });

        return services;
    }


}