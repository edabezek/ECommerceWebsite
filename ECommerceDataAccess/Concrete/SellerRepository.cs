using ECommerceDataAccess.Abstract;
using ECommerceEntities;
using ECommerceEntities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDataAccess.Concrete
{
    public class SellerRepository : Repository<Seller>, ISeller
    {
        private EComerceDBAccess _eComerceDBAccess;
        public SellerRepository(EComerceDBAccess eComerceDBAccess) : base(eComerceDBAccess)
        {
            _eComerceDBAccess = eComerceDBAccess;
        }

        public async Task<IEnumerable<Category>> GetSellerWithCategory(Seller seller)
        {
            return await _eComerceDBAccess.Categories.Include(a => a.Sellers == seller).ToListAsync();
        }



    }
}
