using ECommerceEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDataAccess.Abstract
{
    public interface IProduct : IRepository<Product>
    {
        Task<Category> GetCategoryWithProductAsync(Product product);
    }
}
