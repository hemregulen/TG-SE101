using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TG_SE101.Application.Query.Waybill
{
    public class GetWaybillsQuery : IRequest<List<WaybillDto>>
    {
    }
    public class WaybillDto
    {
        public int Id { get; set; }
        public string WaybillNumber { get; set; }
        public bool IsSend { get; set; }
        public string OrderNumber { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string PhoneNumber { get; set; }
        public List<WaybillOrderItemDto> Items { get; set; }
    }
    public class WaybillOrderItemDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => UnitPrice * Quantity;
    }
}
