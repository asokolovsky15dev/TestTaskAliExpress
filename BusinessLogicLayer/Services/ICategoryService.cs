using DataAccessLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

using BusinessLogicLayer.Models;

namespace BusinessLogicLayer.Services
{
    public interface ICategoryService
    {
        public Task<int> AddCategoryAsync(Category entity);
        
        public Task<int> UpdateCategoryAsync(Category entity);
        
        public Task<IEnumerable<CategoryTree>> GetCategoriesTreeAsync();
    }
}
