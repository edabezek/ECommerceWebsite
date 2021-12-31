using ECommerceEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBusinnes.Abstract
{
    public interface ICategoryServices
    {
        Task<Category> CreateCategory(Category category);
        Task<Category> GetCategoryById(int id);
        Task<IEnumerable<Category>> GetAllCategory();
        Task<Category> UpdateCategory(Category category);
        void DeleteCategory(Category category);
    }
}
