using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TG_SE101.Domain.Model;

namespace TG_SE101.Infrastructure.Repository
{
    public interface IRepository<TEntity, TContext> where TEntity : BaseEntity where TContext : DbContext
    {
        IQueryable<TEntity> Table { get; }
        IQueryable<TEntity> Select(Expression<Func<TEntity, bool>> filterExpression = null);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
        TEntity GetById(int id);
        void SaveChanges();
    }
}
