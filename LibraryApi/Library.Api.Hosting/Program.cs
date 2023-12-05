using Library.Core.Application;
using Library.Api.Controllers;
using Library.Data.Adapters;

var builder = WebApplication.CreateBuilder(args);

#region ServiceConfiguration

// Add Application Services
builder.Services.AddApplicationServices();

// Add Api Services
builder.Services.AddApiServices();

// Add Data Services
builder.Services.AddSqlDataServices();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

