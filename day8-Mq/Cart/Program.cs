using Cart;
using NewRabbitMq.Models;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using NewRabbitMq.src;
using Cart.Models;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddSingleton<Consumer>();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<CartProducer>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/cart", async (IConfiguration configuration) =>
{
    // Create a connection with rabbitMq params
    var factory = new ConnectionFactory();
    configuration.GetSection("RabbitMq").Bind(factory);

    using var connection = await factory.CreateConnectionAsync();
    using var channel = await connection.CreateChannelAsync();  // Create channel

    var result = await channel.BasicGetAsync("product-queue", autoAck: true);  // Get from product-queue present in the channel

    if (result == null)
        return Results.NotFound("No messages in queue.");

    // Convert the result to the desired format
    var message = Encoding.UTF8.GetString(result.Body.ToArray());
    var productsInCart = JsonSerializer.Deserialize<Product>(message);

    
    if (productsInCart != null)
    {
        //_cart.Add(productsInCart);
        // Calculate totalPrice and send it to the cart-queue through which payment will get the data
        var productList = new List<Product>() { productsInCart };
        decimal totalPrice = 0;
        foreach(var p in productList) { totalPrice = p.Quantity * p.Price; }
        CartStructure cart = new CartStructure() { products = productList, totalPrice = totalPrice };
        CartProducer._cart = cart;
    }

    return Results.Ok(productsInCart);
});

// Publish cart to cart-queue
app.MapPost("/checkout", async (CartProducer cartProducer) =>
{
    if (CartProducer._cart == null)
        return Results.BadRequest("Cart is empty.");

    await cartProducer.SendProductToCart();
    return Results.Ok(CartProducer._cart);
});

app.Run();
