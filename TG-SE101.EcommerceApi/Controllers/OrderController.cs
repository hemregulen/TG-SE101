using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TG_SE101.Application.Commands.Order;

namespace TG_SE101.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] AddOrderCommand command)
        {
            if (command == null)
                return BadRequest("Invalid order payload.");
            var result = await _mediator.Send(command);
            if (result == 0)
                return BadRequest("Sipariş oluşturulamadı. Yetersiz stok.");
            return Ok(new { OrderId = result });
        }

    }
}
