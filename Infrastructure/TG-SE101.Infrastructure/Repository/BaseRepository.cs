using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TG_SE101.Domain.Model;

namespace TG_SE101.Infrastructure.Repository
{
    public class BaseRepository<TEntity, TContext> : IRepository<TEntity, TContext> where TEntity : BaseEntity where TContext : DbContext
    {
        private readonly DbSet<TEntity> _dbSet;
        protected readonly TContext _context;
        protected readonly Expression<Func<TEntity, bool>> _defaultFilter;
        public BaseRepository(TContext context, Expression<Func<TEntity, bool>> defaultFilter = null)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = context.Set<TEntity>();
            _defaultFilter = defaultFilter;
        }
        public IQueryable<TEntity> Table => _dbSet.AsQueryable();

        public void Delete(int id)
        {
            TEntity entity = GetById(id);
            if (_context.Entry(entity).State == EntityState.Detached)
                _dbSet.Attach(entity);
            _dbSet.Remove(entity);
        }
        public void Update(TEntity entity)
        {
            var local = _context.Set<TEntity>().Local.FirstOrDefault(e => e.Id == entity.Id);
            if (local != null)
                _context.Entry(local).State = EntityState.Detached;
            entity.UpdateDate = DateTime.UtcNow;
            _context.Entry(entity).State = EntityState.Modified;
        }
        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }
        protected virtual IQueryable<TEntity> GetDbSetForSelect()
        {
            IQueryable<TEntity> dbSetResult = _dbSet.AsNoTracking();
            if (_defaultFilter != null)
                dbSetResult = dbSetResult.Where(_defaultFilter);
            return dbSetResult;
        }
        public IQueryable<TEntity> Select(Expression<Func<TEntity, bool>> filterExpression = null)
        {
            return filterExpression == null ? GetDbSetForSelect() : GetDbSetForSelect().Where(filterExpression);
        }

        public TEntity GetById(int id)
        {
            return GetDbSetForSelect().FirstOrDefault(e => e.Id == id);
        }
        public void SaveChanges()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Database operation failed");
            }
        }
    }
}
