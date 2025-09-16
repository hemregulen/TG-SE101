using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace TG_SE101.ProductApi.Messaging
{
    public class RabbitMQConsumer
    {
        private readonly string _hostname;
        private readonly int _port;
        private readonly string _username;
        private readonly string _password;

        public RabbitMQConsumer(IConfiguration configuration)
        {
            _hostname = configuration["RabbitMQ:HostName"];
            _port = int.Parse(configuration["RabbitMQ:Port"] ?? "5672");
            _username = configuration["RabbitMQ:UserName"];
            _password = configuration["RabbitMQ:Password"];
        }

        public async Task Consume()
        {
            string queueName = "mail-waybill";
            var factory = new ConnectionFactory
            {
                HostName = _hostname,
                UserName = _username,
                Password = _password,
                Port = _port
            };

            await using var connection = await factory.CreateConnectionAsync();
            await using var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(queue: queueName, durable: false, exclusive: false, autoDelete: false);

            var consumer = new AsyncEventingBasicConsumer(channel);

            consumer.ReceivedAsync += async (sender, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(body);
                await Task.Yield();
            };
            await channel.BasicConsumeAsync(
                queue: queueName,
                autoAck: true,
                consumer: consumer
            );
        }
    }
}
