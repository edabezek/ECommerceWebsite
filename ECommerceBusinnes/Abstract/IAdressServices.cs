using ECommerceEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBusinnes.Abstract
{
    public interface IAdressServices
    {
        Task<Adress> CreateAdress(Adress adress);
        Task<Adress> GetAdressById(int id);
        Task<IEnumerable<Adress>> GetAllAdress();
        Task<Adress> UpdateAdress(Adress adress);
        void DeleteAdress(Adress adress);
    }
}
