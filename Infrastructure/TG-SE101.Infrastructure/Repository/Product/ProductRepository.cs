using System.Linq.Expressions;
using TG_SE101.Domain;
using TG_SE101.Infrastructure.Repository;

namespace TG_SE101.Infrastructure.Product
{
    public class ProductRepository : BaseRepository<Domain.Model.Product, ECommerceDbContext>, IProductRepository
    {
        public ProductRepository(ECommerceDbContext context, Expression<Func<Domain.Model.Product, bool>> defaultFilter = null) : base(context, defaultFilter)
        {
        }
    }
}
