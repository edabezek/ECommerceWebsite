using ECommerceDataAccess.Abstract;
using ECommerceEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDataAccess.Concrete
{
    public class CategoryRepository : Repository<Category>, ICategory
    {
        private EComerceDBAccess _eComerceDBAccess;
        public CategoryRepository(EComerceDBAccess eComerceDBAccess):base (eComerceDBAccess)
        {
            _eComerceDBAccess = eComerceDBAccess;
        }

        public Task<IEnumerable<Product>> GetProductWithCategory(Category category)
        {
            throw new NotImplementedException();
        }
        //public async Task<IEnumerable<Product>> GetProductWithCategory(Category category)
        //{
        //    return await _eComerceDBAccess.Products.Include(a =>a.category.CategoryId == category.CategoryId).ToListAsync;//migrationdan gelecek
        //}
    }
}
