using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TG_SE101.Infrastructure.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
