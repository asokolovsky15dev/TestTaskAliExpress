using System.Threading.Tasks;
using System.Collections.Generic;

using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public interface ICategoryRepository
    {
        public Task<int> AddCategoryAsync(Category category);

        public Task<int> UpdateCategoryAsync(Category category);

        public Task<IEnumerable<Category>> GetAllCategoriesAsync();

    }
}
