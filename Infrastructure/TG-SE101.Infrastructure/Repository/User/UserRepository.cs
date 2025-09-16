using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TG_SE101.Domain;
using TG_SE101.Infrastructure.Product;

namespace TG_SE101.Infrastructure.Repository.User
{
    public class UserRepository : BaseRepository<Domain.Model.User, ECommerceDbContext>, IUserRepository
    {
        public UserRepository(ECommerceDbContext context, Expression<Func<Domain.Model.User, bool>> defaultFilter = null) : base(context, defaultFilter)
        {
        }
    }
}
