using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TG_SE101.Domain.Model
{
    public class Order:BaseEntity
    {
        public string Number { get; set; }
        public decimal TotalAmount { get; set; }
        public int CustomerId { get; set; }
        public User Customer { get; set; }
        public Waybill Waybill { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}
