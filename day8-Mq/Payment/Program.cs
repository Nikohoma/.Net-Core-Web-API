using Cart.Models;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/payment", async (IConfiguration configuration) =>
{
    var factory = new ConnectionFactory();
    configuration.GetSection("RabbitMq").Bind(factory);

    using var connection = await factory.CreateConnectionAsync();
    using var channel = await connection.CreateChannelAsync();

    await channel.QueueDeclareAsync(
        queue: "cart-queue",
        durable: false,
        exclusive: false,
        autoDelete: false,
        arguments: null
    );

    var result = await channel.BasicGetAsync("cart-queue", autoAck: true);

    if (result == null)
        return Results.NotFound("No messages in queue.");

    var message = Encoding.UTF8.GetString(result.Body.ToArray());
    var cart = JsonSerializer.Deserialize<CartStructure>(message);

    return Results.Ok(new
    {
        products = cart?.products,
        totalPrice = cart?.totalPrice
    });
});

app.Run();