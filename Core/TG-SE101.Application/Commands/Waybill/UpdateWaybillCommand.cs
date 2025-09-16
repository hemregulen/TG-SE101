using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TG_SE101.Application.Commands.Waybill
{
    public class UpdateWaybillCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
