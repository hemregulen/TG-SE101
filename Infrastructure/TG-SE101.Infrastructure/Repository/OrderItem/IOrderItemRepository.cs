using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TG_SE101.Domain;

namespace TG_SE101.Infrastructure.Repository.OrderItem
{
    public interface IOrderItemRepository : IRepository<Domain.Model.OrderItem, ECommerceDbContext>
    {
    }
}
