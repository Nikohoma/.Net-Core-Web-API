using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory() { HostName = "localhost" };

using var connection = factory.CreateConnection();  // Opens TCP Connection on port 5672
using var channel = connection.CreateModel();  // Create channel inside the connection

channel.QueueDeclare(
    queue: "demo.queue",  // name of the queue to connect to
    durable: true,     // true if queue already exist. False to create new queue
    exclusive: false,  // queue can be accessed by multiple connection
    autoDelete: false, 
    arguments: null  // no constraints like max length
);

// Limit unacknowledged messages to 1 at a time
channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

var consumer = new EventingBasicConsumer(channel); // fire an event every time a new message arrives

consumer.Received += (model, ea) =>  // BasicDeliverEventArgs ea : Contains everything about the received message ; Object model : represents the channel that received the message
{
    var body = ea.Body.ToArray();  // gets raw message as byte array
    var message = Encoding.UTF8.GetString(body); // Converts to string
    Console.WriteLine($"Received: {message}");  // prints the message

    // Manually acknowledge after processing
    channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);  // Tells RabbitMq to remove message after consuming is done
};

channel.BasicConsume(
    queue: "demo.queue",
    autoAck: false,       // false = manual acknowledgment to delete message
    consumer: consumer
);

Console.WriteLine("Waiting for messages. Press [Enter] to exit.");
Console.ReadLine();