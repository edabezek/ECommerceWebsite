
using ECommerceBusinnes.Abstract;
using ECommerceDataAccess.Abstract;
using ECommerceDataAccess.Concrete;
using ECommerceEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBusinnes.Concrete
{
    public class AdressServices : IAdressServices
    {
        private IUnitOfWork _unitOfWork;
        public AdressServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;    
        }
        public async Task<Adress> CreateAdress(Adress adress)
        {
            return await _unitOfWork.Address.AddAsync(adress);
        }

        public void DeleteAdress(Adress adress)
        {
            _unitOfWork.Address.RemoveAsync(adress);
            _unitOfWork.CommitAsync();
        }

        public async Task<Adress> GetAdressById(int id)
        {
            return await _unitOfWork.Address.GetById(id);
        }

        public async Task<IEnumerable<Adress>> GetAllAdress()
        {
            return await _unitOfWork.Address.GetAllAsync();
        }

        public async Task<Adress> UpdateAdress(Adress adress)
        {
             _unitOfWork.Address.Update(adress);
            await _unitOfWork.CommitAsync();
            return adress;
        }
    }
}
