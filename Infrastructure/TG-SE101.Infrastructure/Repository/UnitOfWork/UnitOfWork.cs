using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TG_SE101.Domain;

namespace TG_SE101.Infrastructure.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ECommerceDbContext _context;

        public UnitOfWork(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
        public void BeginTransaction() => _context.Database.BeginTransaction();
        public void Commit() => _context.Database.CommitTransaction();
        public void Rollback() => _context.Database.RollbackTransaction();

    }
}
