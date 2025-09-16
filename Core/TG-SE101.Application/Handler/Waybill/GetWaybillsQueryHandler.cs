using Azure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TG_SE101.Application.Query.Waybill;
using TG_SE101.Infrastructure.Repository.Order;
using TG_SE101.Infrastructure.Repository.Waybill;

namespace TG_SE101.Application.Handler.Waybill
{
    public class GetWaybillsQueryHandler : IRequestHandler<GetWaybillsQuery, List<WaybillDto>>
    {
        private readonly IOrderRepository _orderRepository;
        public GetWaybillsQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<List<WaybillDto>> Handle(GetWaybillsQuery request, CancellationToken cancellationToken)
        {
            var listOfWaybillWithoutSend = _orderRepository.Table
                .Include(x => x.Waybill)
                .Include(x => x.Customer)
                .ThenInclude(x => x.Orders)
                .Where(x=>!x.Waybill.IsSend)
                .Select(x=> new WaybillDto 
                {
                    Id=x.Waybill.Id,
                    IsSend= x.Waybill.IsSend,
                    DisplayName= x.Customer.FirstName+" "+x.Customer.LastName,
                    Email=x.Customer.Email,
                    PhoneNumber=x.Customer.Phone,
                    OrderNumber=x.Number,
                    WaybillNumber=x.Waybill.WaybillNumber,
                    Items= x.Items.Select(oi=> new WaybillOrderItemDto
                    {
                        ProductName=oi.ProductName,
                        Quantity=oi.Quantity,
                        UnitPrice=oi.UnitPrice
                    }).ToList()
                })
                .ToList();
            return listOfWaybillWithoutSend;
        }
    }
}
