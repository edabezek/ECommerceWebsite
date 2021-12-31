using ECommerceDataAccess.Abstract;
using ECommerceEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDataAccess.Concrete
{
    public class ProductRepository : Repository<Product>, IProduct
    {
        private EComerceDBAccess _eCommerceDBAccess;
        public ProductRepository(EComerceDBAccess eComerceDBAccess) :base(eComerceDBAccess)
        {
            _eCommerceDBAccess = eComerceDBAccess;
        }
        public async Task<Category> GetCategoryWithProductAsync(Product product)
        {
            return await _eCommerceDBAccess.Categories.Include(w => w.Products == product).FirstOrDefaultAsync();
        }
    }
}
