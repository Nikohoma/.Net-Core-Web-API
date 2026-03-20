using RabbitMQ.Client;
using System.Text;
using NewRabbitMq.Data;
using System.Text.Json;
using NewRabbitMq.Models;
using Cart.Models;

namespace NewRabbitMq.src
{
    public class CartProducer
    {
        public static CartStructure _cart;

        private readonly IConfiguration _configuration;
        public CartProducer(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task SendProductToCart()
        {
            // 1. Create a connection factory
            var factory = new ConnectionFactory();
            _configuration.GetSection("RabbitMq").Bind(factory);

            // 2. Open connection and channel
            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            // 3. Declare a queue (creates it if it doesn't exist)
            await channel.QueueDeclareAsync(
                queue: "cart-queue",
                durable: false,      // survives broker restart if true
                exclusive: false,
                autoDelete: false,
                arguments: null
        );
          

            // 4. Publish a message
            string message = JsonSerializer.Serialize(_cart.totalPrice);
            //string message = JsonSerializer.Serialize("Amount To Pay : "+_cart.totalPrice);
            var body = Encoding.UTF8.GetBytes(message);

            await channel.BasicPublishAsync(
                exchange: "",          // default exchange
                routingKey: "cart-queue",
                body: body
            );

            Console.WriteLine($"Sent: {message}");
        }
    }


}
