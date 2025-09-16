using System.Linq.Expressions;
using TG_SE101.Domain;

namespace TG_SE101.Infrastructure.Repository.Order
{
    public class OrderRepository : BaseRepository<Domain.Model.Order, ECommerceDbContext>, IOrderRepository
    {
        public OrderRepository(ECommerceDbContext context, Expression<Func<Domain.Model.Order, bool>> defaultFilter = null) : base(context, defaultFilter)
        {
        }
    }
}
