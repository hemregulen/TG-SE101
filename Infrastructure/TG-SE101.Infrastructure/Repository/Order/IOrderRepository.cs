using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TG_SE101.Domain;

namespace TG_SE101.Infrastructure.Repository.Order
{
    public interface IOrderRepository : IRepository<Domain.Model.Order, ECommerceDbContext>
    {
    }
}
