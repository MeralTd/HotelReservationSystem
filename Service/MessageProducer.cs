using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Service;

public class MessageProducer : IMessageProducer
{
    private readonly IConfiguration _configuration;

    public MessageProducer(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void SendingMessage<T>(T message)
    {

        var factory = new ConnectionFactory()
        {
            HostName = _configuration["RabbitMQ:HostName"],
            UserName = _configuration["RabbitMQ:UserName"],
            Password = _configuration["RabbitMQ:Password"],
            VirtualHost = "/"
        };

        var connection = factory.CreateConnection();

        using var channel = connection.CreateModel();

        //channel.QueueDeclare("reservations", durable: true, exclusive: true);
        channel.QueueDeclare(queue: "reservations",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

        var jsonString = JsonSerializer.Serialize(message);
        var body = Encoding.UTF8.GetBytes(jsonString);

        channel.BasicPublish("", "reservations", body: body);

    }
}