using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<TodoContext>(opt =>
    opt.UseInMemoryDatabase("TodoList"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // // Tutorial: Call an ASP.NET Core web API with JavaScript
    // // https://learn.microsoft.com/en-us/aspnet/core/tutorials/web-api-javascript?view=aspnetcore-8.0
    // app.UseDeveloperExceptionPage();

    // Tutorial: Create a web API with ASP.NET Core
    // https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&tabs=visual-studio-code
    // Enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwagger();
    app.UseSwaggerUI(options => // UseSwaggerUI is called only in Development.
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

// // Tutorial: Call an ASP.NET Core web API with JavaScript _START
// app.UseDefaultFiles();
// app.UseStaticFiles();
// // Tutorial: Call an ASP.NET Core web API with JavaScript _END

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
