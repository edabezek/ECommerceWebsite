using ECommerceEntities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBusinnes.Abstract
{
    public interface ISellerServices
    {
        Task<Seller> CreateSeller(Seller seller);
        Task<Seller> GetSellerById(int id);
        Task<IEnumerable<Seller>> GetAllSeller();
        Task<Seller> UpdateSeller(Seller seller);
        void DeleteSeller(Seller seller);
    }
}
