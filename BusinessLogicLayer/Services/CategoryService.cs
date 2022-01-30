using System.Collections.Generic;
using System.Threading.Tasks;

using BusinessLogicLayer.Models;
using BusinessLogicLayer.Utilities;
using DataAccessLayer;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<int> AddCategoryAsync(Category category)
        {
            return await _categoryRepository.AddCategoryAsync(category);
        }
              
        public async Task<int> UpdateCategoryAsync(Category category)
        {
            return await _categoryRepository.UpdateCategoryAsync(category);
        }

        public async Task<IEnumerable<CategoryTree>> GetCategoriesTreeAsync()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            var tree = categories.GenerateTree(x => x.Id, x => x.ParentId);

            return tree;
        }

        

    }
}
