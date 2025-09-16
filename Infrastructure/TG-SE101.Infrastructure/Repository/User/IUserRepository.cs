using TG_SE101.Domain;
using TG_SE101.Domain.Model;

namespace TG_SE101.Infrastructure.Repository.User
{
    public interface IUserRepository : IRepository<Domain.Model.User, ECommerceDbContext>
    {
    }
}