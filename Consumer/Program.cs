using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Net;
using System.Net.Mail;
using System.Text;

var factory = new ConnectionFactory()
{
    HostName = "localhost",
    UserName = "user",
    Password = "mypassword",
    VirtualHost = "/"

};

var connection = factory.CreateConnection();
var channel = connection.CreateModel();

//channel.QueueDeclare(queue: "reservations",
//                     durable: true,
//                     exclusive: false);



channel.QueueDeclare(queue: "reservations",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (model, eventArgs) =>
{
    var body = eventArgs.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($"Received message: {message}");

    var data = JObject.Parse(message);



    //Send Email


    using (var client = new SmtpClient())
    {
        client.Host = "smtp.gmail.com";
        client.Port = 587;
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.UseDefaultCredentials = false;
        client.EnableSsl = true;
        client.Credentials = new NetworkCredential("meraltsdmrr@gmail.com", "hztegqjizoqudcva");
        using (var msg = new MailMessage(
            from: new MailAddress("meraltsdmrr@gmail.com", "Meral Taşdemir"),
            to: new MailAddress(data["Email"].ToString(), data["UserName"].ToString())
            ))
        {

            msg.Subject = "Your reservation has been confirmed";
            msg.Body = "Hello " + data["UserName"] + ", your reservation at hotel " + data["HotelName"] + " has been confirmed.";

            client.Send(msg);
        }
    }
};
channel.BasicConsume("reservations", true, consumer);


Console.ReadKey();