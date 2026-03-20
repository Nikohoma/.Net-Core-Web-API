using RabbitMQ.Client;
using System.Text;
using NewRabbitMq.Data;
using System.Text.Json;

namespace NewRabbitMq.src
{
    public class Producer
    {
        private readonly IConfiguration _configuration;
        public Producer(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendProductToCart(int id, int q)
        {
            // 1. Create a connection factory
            var factory = new ConnectionFactory();  
            _configuration.GetSection("RabbitMq").Bind(factory) ;

            // 2. Open connection and channel
            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            // 3. Declare a queue (creates it if it doesn't exist)
            await channel.QueueDeclareAsync(
                queue: "product-queue",
                durable: false,      // survives broker restart if true
                exclusive: false,
                autoDelete: false,
                arguments: null
        );

            var productsToSend = Products.products.FirstOrDefault(p => p.Id == id);

            if (productsToSend != null)
            {
                productsToSend.Quantity = q;

                // 4. Publish a message
                string message = JsonSerializer.Serialize(productsToSend);
                var body = Encoding.UTF8.GetBytes(message);

                await channel.BasicPublishAsync(
                    exchange: "",          // default exchange
                    routingKey: "product-queue",
                    body: body
                );

                Console.WriteLine($"Sent: {message}");
            }
            else { Console.WriteLine("Product Not Found");return; }
        }
    }

    
}
