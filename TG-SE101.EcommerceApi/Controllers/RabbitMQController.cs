using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using TG_SE101.ProductApi.Messaging;

namespace TG_SE101.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitMQController : ControllerBase
    {
        private readonly RabbitMQConsumer _consumer; 
        private readonly IConfiguration _configuration;
        public RabbitMQController(IConfiguration configuration)
        {
            _configuration = configuration;
            _consumer = new RabbitMQConsumer(_configuration);
        }
        [HttpPost("consumer")]
        public async Task<IActionResult> Consume()
        {
            _consumer.Consume();
            return Ok("Kuyrukta mesaj yok veya zaman aşımı.");
        }
    }
}
