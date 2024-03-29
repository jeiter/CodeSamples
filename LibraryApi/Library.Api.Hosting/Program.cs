﻿using Library.Core.Application;
using Library.Api.Controllers;
using Library.Data.Adapters.Postgres;

var builder = WebApplication.CreateBuilder(args);

#region ServiceConfiguration

// Add Application Services
builder.Services.AddApplicationServices();

// Add Api Services
builder.Services.AddApiServices(builder.Configuration);

// Add Data Services
builder.Services.AddPostgresDataServices(builder.Configuration.GetConnectionString("LibraryDatabase"));

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.UseHealthChecks("/health");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
