using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDataAccess.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync();
        ICategory Category { get; }
        IProduct Product { get; }
        IAddress Address { get; }
        ISeller Seller { get; }
    }
}
