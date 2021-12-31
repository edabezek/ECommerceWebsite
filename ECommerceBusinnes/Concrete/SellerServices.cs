using ECommerceBusinnes.Abstract;
using ECommerceDataAccess.Abstract;
using ECommerceEntities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBusinnes.Concrete
{
    public class SellerServices : ISellerServices
    {
        private IUnitOfWork _unitOfWork;
        public SellerServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Seller> CreateSeller(Seller seller)
        {
            var result =await _unitOfWork.Seller.AddAsync(seller);
            await _unitOfWork.CommitAsync();//  :(
            return result;
        }

        public void DeleteSeller(Seller seller)
        {
            _unitOfWork.Seller.RemoveAsync(seller);
            _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Seller>> GetAllSeller()
        {
            return await _unitOfWork.Seller.GetAllAsync();
        }

        public async Task<Seller> GetSellerById(int id)
        {
            return await _unitOfWork.Seller.GetById(id);
        }

        public async Task<Seller> UpdateSeller(Seller seller)
        {
            _unitOfWork.Seller.Update(seller);
            await _unitOfWork.CommitAsync();
            return seller;
        }
    }
}
