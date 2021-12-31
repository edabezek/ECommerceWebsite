using ECommerceEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBusinnes.Abstract
{
    public interface IProductServices
    {
        Task<Product> CreateProduct(Product product);
        Task<Product> GetProductById(int id);
        Task<IEnumerable<Product>> GetAllProduct();
        Task<Product> UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
}
