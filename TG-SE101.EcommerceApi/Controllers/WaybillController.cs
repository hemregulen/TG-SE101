using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using TG_SE101.Application.Query.Waybill;
using TG_SE101.ProductApi.Messaging;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TG_SE101.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaybillController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly RabbitMQPublisher _publisher;
        private readonly IConfiguration _configuration;
        public WaybillController(IMediator mediator, IConfiguration configuration)
        {
            _configuration = configuration;
            _mediator = mediator;
            _publisher = new RabbitMQPublisher(_configuration);
        }

        [HttpPost("publish")]
        public async Task<IActionResult> Publish()
        {
            var listOfWaybill=_mediator.Send(new GetWaybillsQuery());
            if (listOfWaybill.Result.Any())
            {
                foreach (var item in listOfWaybill.Result)
                {
                    var json=JsonConvert.SerializeObject(item);
                    await _publisher.PublishAsync("mail-waybill", json);
                    await _mediator.Send(new Application.Commands.Waybill.UpdateWaybillCommand { Id = item.Id });
                }
            }
            return Ok("Message published!");
        }
    }
}
