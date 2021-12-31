using ECommerceEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDataAccess.Abstract
{
    public interface ICategory : IRepository<Category>
    {
        Task<IEnumerable<Product>> GetProductWithCategory(Category category);
    }
}
