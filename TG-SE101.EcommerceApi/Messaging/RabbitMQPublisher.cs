using Microsoft.AspNetCore.Connections;
using RabbitMQ.Client;
using System.Text;

namespace TG_SE101.ProductApi.Messaging
{
    public class RabbitMQPublisher
    {
        private readonly string _hostname;
        private readonly int _port;
        private readonly string _username;
        private readonly string _password;

        public RabbitMQPublisher(IConfiguration configuration)
        {
            _hostname = configuration["RabbitMQ:HostName"];
            _port = int.Parse(configuration["RabbitMQ:Port"] ?? "5672");
            _username = configuration["RabbitMQ:UserName"];
            _password = configuration["RabbitMQ:Password"];
        }

        public async Task PublishAsync(string queueName, string message)
        {
            var factory = new ConnectionFactory
            {
                HostName = _hostname,
                Port = _port,           
                UserName = _username,
                Password = _password
            };

            await using var connection = await factory.CreateConnectionAsync();
            await using var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(
                queue: queueName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );

            var body = Encoding.UTF8.GetBytes(message);

            await channel.BasicPublishAsync(
                exchange: "",
                routingKey: queueName,
                mandatory: false,
                body: body
            );
        }
    }
}
