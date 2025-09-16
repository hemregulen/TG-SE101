using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TG_SE101.Domain;
using TG_SE101.Infrastructure.Repository.Order;

namespace TG_SE101.Infrastructure.Repository.OrderItem
{
    public class OrderItemRepository : BaseRepository<Domain.Model.OrderItem, ECommerceDbContext>, IOrderItemRepository
    {
        public OrderItemRepository(ECommerceDbContext context, Expression<Func<Domain.Model.OrderItem, bool>> defaultFilter = null) : base(context, defaultFilter)
        {
        }
    }
}
