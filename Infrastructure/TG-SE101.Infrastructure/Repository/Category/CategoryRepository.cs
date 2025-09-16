using System.Linq.Expressions;
using TG_SE101.Domain;

namespace TG_SE101.Infrastructure.Repository.Category
{
    public class CategoryRepository : BaseRepository<Domain.Model.Category, ECommerceDbContext>, ICategoryRepository
    {
        public CategoryRepository(ECommerceDbContext context, Expression<Func<Domain.Model.Category, bool>> defaultFilter = null) : base(context, defaultFilter)
        {
        }
    }
}
