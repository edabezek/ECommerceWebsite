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
    public class CategoryServices : ICategoryServices
    {
        private IUnitOfWork _unitOfWork;
        public CategoryServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Category> CreateCategory(Category category)
        {
            return await _unitOfWork.Category.AddAsync(category);
        }

        public void DeleteCategory(Category category)
        {
            _unitOfWork.Category.RemoveAsync(category);
            _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            return await _unitOfWork.Category.GetAllAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _unitOfWork.Category.GetById(id);
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            _unitOfWork.Category.Update(category);
            await _unitOfWork.CommitAsync();
            return category;
        }
    }
}
