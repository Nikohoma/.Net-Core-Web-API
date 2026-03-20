using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NewRabbitMq.src;
using System.Reflection.Metadata.Ecma335;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<Producer>();
//builder.Services.AddHostedService<Consumer>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/product/send/{id}", async (int id,[FromQuery] int quantity, Producer producer) =>
{
    await producer.SendProductToCart(id,quantity);
    return Results.Ok($"Product {id} sent to cart queue.");
});

//app.MapGet("/test", () => "Hello");

//app.MapPost("/test/input", (int id) => { return Results.Ok($"Input id is {id}"); });

app.Run();