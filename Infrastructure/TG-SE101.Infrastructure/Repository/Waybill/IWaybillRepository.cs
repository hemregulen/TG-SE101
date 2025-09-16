using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TG_SE101.Domain;

namespace TG_SE101.Infrastructure.Repository.Waybill
{
    public interface IWaybillRepository : IRepository<Domain.Model.Waybill, ECommerceDbContext>
    {
    }
}
