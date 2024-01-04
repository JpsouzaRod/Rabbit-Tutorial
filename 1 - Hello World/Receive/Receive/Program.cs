using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var factory = new ConnectionFactory { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "amq.gen-JpwzeGAjzz1Gc-lAf9Ufpw");

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($" [x] Received {message}");
};
channel.BasicConsume(queue: "amq.gen-JpwzeGAjzz1Gc-lAf9Ufpw",
                     autoAck: true,
                     consumer: consumer);


Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();
