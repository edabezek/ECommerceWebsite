using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDataAccess.Abstract
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);
        void RemoveAsync(TEntity entity);
        TEntity Update(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetById(int id);//remove needed
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}
