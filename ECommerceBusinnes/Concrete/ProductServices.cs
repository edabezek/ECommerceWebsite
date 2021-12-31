using ECommerceBusinnes.Abstract;
using ECommerceDataAccess.Abstract;
using ECommerceEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBusinnes.Concrete
{
    public class ProductServices : IProductServices
    {
        private IUnitOfWork _unitOfWork;
        public ProductServices(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<Product> CreateProduct(Product product)
        {
            return await _unitOfWork.Product.AddAsync(product);
        }

        public void DeleteProduct(Product product)
        {
            _unitOfWork.Product.RemoveAsync(product);
            _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            return await _unitOfWork.Product.GetAllAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _unitOfWork.Product.GetById(id) ;//async method is none
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            _unitOfWork.Product.Update(product);
            await _unitOfWork.CommitAsync();
            return product;
        }
    }
}
