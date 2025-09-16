using TG_SE101.Domain;

namespace TG_SE101.Infrastructure.Repository.Category
{
    public interface ICategoryRepository : IRepository<Domain.Model.Category, ECommerceDbContext>
    {
    }
}
