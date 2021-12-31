using ECommerceDataAccess.Abstract;
using ECommerceEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceDataAccess.Concrete
{
    public class AddressRepository : Repository<Adress>,IAddress
    {
        private EComerceDBAccess _eComerceDBAccess;
        public AddressRepository(EComerceDBAccess eComerceDBAccess) : base(eComerceDBAccess)
        {
            _eComerceDBAccess = eComerceDBAccess;    
        }
    }
}
