using ECommerceEntities;
using ECommerceEntities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDataAccess.Abstract
{
    public interface ISeller : IRepository<Seller>
    {
        Task<IEnumerable<Category>> GetSellerWithCategory(Seller seller);
    }
}
