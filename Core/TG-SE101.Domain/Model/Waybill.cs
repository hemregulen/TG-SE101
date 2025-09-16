using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TG_SE101.Domain.Model
{
    public class Waybill:BaseEntity
    {
        public string WaybillNumber { get; set; }
        public bool IsSend { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
