using RabbitMQ.Client;
using System.Text;

namespace Para.Api.Services
{
    public class EmailQueueService : IEmailQueueService
    {
        private readonly ConnectionFactory _factory;
        private readonly string _queueName = "emailQueue";

        public EmailQueueService()
        {
            _factory = new ConnectionFactory() { HostName = "localhost" };
        }

        public void QueueEmail(string email)
        {
            using (var connection = _factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                // Kuyruğu oluştur
                channel.QueueDeclare(queue: _queueName,
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var body = Encoding.UTF8.GetBytes(email);

                channel.BasicPublish(exchange: "",
                                     routingKey: _queueName,
                                     basicProperties: null,
                                     body: body);
            }
        }
    }
}
