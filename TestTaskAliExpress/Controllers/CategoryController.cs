using System.Threading.Tasks;
using BusinessLogicLayer.Services;
using DataAccessLayer.Models;

using Microsoft.AspNetCore.Mvc;

namespace TestTaskAliExpress.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoriesTree()
        {
            var categories = await _categoryService.GetCategoriesTreeAsync();
            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(Category category)
        {
            var result = await _categoryService.AddCategoryAsync(category);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            var result = await _categoryService.UpdateCategoryAsync(category);
            return Ok(result);
        }
    }
}
