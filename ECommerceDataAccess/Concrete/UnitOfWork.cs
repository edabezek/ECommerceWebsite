using ECommerceDataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDataAccess.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private EComerceDBAccess _eCommerceDBAccess;
        private CategoryRepository categoryRepository;
        private ProductRepository productRepository;
        private AddressRepository addressRepository;
        private SellerRepository sellerRepository;
        public UnitOfWork(EComerceDBAccess eComerceDBAccess) 
        {
            _eCommerceDBAccess = eComerceDBAccess;
        }
        public ICategory Category => categoryRepository = categoryRepository ?? new CategoryRepository(_eCommerceDBAccess);
        public IProduct Product => productRepository = productRepository ?? new ProductRepository(_eCommerceDBAccess);
        public IAddress Address => addressRepository = addressRepository ?? new AddressRepository(_eCommerceDBAccess);
        public ISeller Seller => sellerRepository = sellerRepository ?? new SellerRepository(_eCommerceDBAccess);

        public async Task<int> CommitAsync()
        {
            return await _eCommerceDBAccess.SaveChangesAsync();
        }

        public void Dispose()
        {
            _eCommerceDBAccess.Dispose();
        }
    }
}
