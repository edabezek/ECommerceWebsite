using ECommerceDataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDataAccess.Concrete
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private EComerceDBAccess _eComerceDBAccess;
        public Repository(EComerceDBAccess eComerceDBAccess)
        {
            _eComerceDBAccess = eComerceDBAccess;
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _eComerceDBAccess.Set<TEntity>().AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _eComerceDBAccess.Set<TEntity>().AddRangeAsync(entities);
            return entities;
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _eComerceDBAccess.Set<TEntity>().Where(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _eComerceDBAccess.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _eComerceDBAccess.Set<TEntity>().FindAsync(id);
        }

        public void RemoveAsync(TEntity entity)
        {
            _eComerceDBAccess.Set<TEntity>().Remove(entity);
        }

        public TEntity Update(TEntity entity)
        {
            _eComerceDBAccess.Set<TEntity>().Update(entity);
            return entity;
        }
    }
}
