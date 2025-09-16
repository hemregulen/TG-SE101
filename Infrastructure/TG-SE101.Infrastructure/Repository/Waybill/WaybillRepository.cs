using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TG_SE101.Domain;
using TG_SE101.Infrastructure.Repository.User;

namespace TG_SE101.Infrastructure.Repository.Waybill
{
    public class WaybillRepository : BaseRepository<Domain.Model.Waybill, ECommerceDbContext>, IWaybillRepository
    {
        public WaybillRepository(ECommerceDbContext context, Expression<Func<Domain.Model.Waybill, bool>> defaultFilter = null) : base(context, defaultFilter)
        {
        }
    }
}
