using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
//using MongoDB.Bson;
//using MongoDB.Driver;


var builder = WebApplication.CreateBuilder(args);

//var client = new MongoClient("mongodb://localhost:27017/");
//var testDb = client.GetDatabase("TestApp");
//var collection = testDb.GetCollection<TodoItem>("todos");

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<TodoContext>(opt =>
    opt.UseInMemoryDatabase("TodoList"));

//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new() { Title = "TodoApi", Version = "v1" });
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseDefaultFiles();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();