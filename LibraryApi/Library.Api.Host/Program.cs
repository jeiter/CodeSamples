using Library.Core.Application;
using Library.Api.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add Application Services
builder.Services.AddApplicationServices();

// Add Api Services
builder.Services.AddApiServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

