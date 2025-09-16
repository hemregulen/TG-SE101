using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TG_SE101.Application.Commands.Waybill;
using TG_SE101.Application.Query.Waybill;
using TG_SE101.Infrastructure.Repository.Waybill;

namespace TG_SE101.Application.Handler.Waybill
{
    public class UpdateWaybillCommandHandler : IRequestHandler<UpdateWaybillCommand, int>
    {
        private readonly IWaybillRepository _waybillRepository;
        public UpdateWaybillCommandHandler(IWaybillRepository waybillRepository)
        {
            _waybillRepository = waybillRepository;
        }
        public async Task<int> Handle(UpdateWaybillCommand request, CancellationToken cancellationToken)
        {
            var waybill=_waybillRepository.GetById(request.Id);
            if (waybill!=null)
            {
                waybill.IsSend = true;
                _waybillRepository.Update(waybill);
                _waybillRepository.SaveChanges();
                return 1;
            }
            return 0;
        }
    }
}
