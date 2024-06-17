using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

Console.WriteLine("Welcome to the hotel reservation service");





var factory = new ConnectionFactory()
{
    HostName = "localhost",
    UserName = "user",
    Password = "mypassword",
    VirtualHost = "/"

};


var connection = factory.CreateConnection();
var channel = connection.CreateModel();


channel.QueueDeclare(queue: "reservations",
                      durable: true,
                      exclusive: false,
                      autoDelete: false,
                      arguments: null);

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (model, eventArgs) =>
{
    var body = eventArgs.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);

    Console.WriteLine($"Received message: {message}");
    // E-posta veya SMS gönderme işlemi burada yapılabilir
};
channel.BasicConsume("reservations", true, consumer);

Console.ReadKey();

