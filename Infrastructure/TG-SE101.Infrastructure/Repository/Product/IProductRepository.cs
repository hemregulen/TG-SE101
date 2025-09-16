using TG_SE101.Domain;
using TG_SE101.Infrastructure.Repository;

namespace TG_SE101.Infrastructure.Product
{
    public interface IProductRepository : IRepository<Domain.Model.Product, ECommerceDbContext>
    {
    }
}
